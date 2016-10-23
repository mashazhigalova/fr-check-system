using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplianceAssessment;

namespace FRCCheckSystem
{
    public partial class CompAssessMaster : System.Web.UI.MasterPage
    {
        public static List<ListItem> files;
        protected string RadValue;
        string success = "<h4><i class=\"material-icons\">done_all</i> Загрузка выполнена</h4>";
        string error = "<h4><i class=\"material-icons\">error_outline</i> Ошибка: </h4>";
        public string outDocsFilePath = "~/App_Data/OutDocs/"; // путь к папке с результирующими файлами
        public string uploadFilePath = "~/App_Data/Upload/"; // путь к папке с загрузками
        public string rulesFilePath = "~/App_Data/RulesRepository/"; // путь к репозиторию
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["template"] != null) // запросить название шаблона, если присутствует
                    if (Request.Cookies["template"].Value == "template.docx")
                    {
                        TemplShow(Request.Cookies["template"].Value);
                        if (Request.Cookies["fileName"] != null) // вывести имя документа, если есть в Cookie
                            if (Request.Cookies["fileName"].Value != "")
                                CheckDocShow(Server.UrlDecode(Request.Cookies["fileName"].Value));
                    }

                string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/RulesRepository/"));
                files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {   // отображение названий в выпадающем списке
                    files.Add(new ListItem(Path.GetFileName(filePath).Replace(".docx", ""), filePath));
                }
                dropDownListWorks.DataSource = files;
                dropDownListWorks.DataBind();

            }
            EnableCheck();
        }
        

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            // удаление файлов в папке Upload
            Check.ClearFolder(HttpContext.Current.Server.MapPath(uploadFilePath));
            panCheck.Visible = true;    // панель с элементами видима
            if (CheckFileUploader.HasFile)  // если файл выбран
                try
                {
                    if (!CheckFileUploader.FileName.Contains(".docx")) // проверка на поддерживаемый формат
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", 
                            "<script>alert('Формат загружаемого файла не поддерживается.');</script>");
                        return;
                    }
                    CheckFileUploader.SaveAs(Server.MapPath(uploadFilePath) +
                         CheckFileUploader.FileName);   // сохранить файл в репозитории
                    successUploadMsg.Text = success; // сообщение об успешной загрузке
                    nameCheckDoc.Text = "";
                    btnFileDelete.Visible = true;
                    string name = CheckFileUploader.PostedFile.FileName; // полное имя файла
                    if (name.Contains(@"\")) // отображение только части пути к файлу - его имени
                        name = name.Remove(0, name.LastIndexOf(@"\") + 1);

                    nameDocCheckLoad.Text = "<i class=\"material-icons\">insert_drive_file</i> " + name;
                    // загрузка в Cookie имени файла
                    Response.Cookies["fileName"].Value = Server.UrlEncode(name);  
                    // проверка на отображение панели с кнопкой для проверки
                    EnableCheck();                                             
                }
                catch (Exception ex)    // ошибка при загрузке документа
                {
                    errorUploadMsg.Text = error;
                    nameCheckDoc.Text = ex.Message.ToString();
                }
            else
                panCheck.Visible = false;   // панель с информацией о загруженном документе невидима
        }
        private void TemplShow(string file)
        {
            panCompare.Visible = true;
            successTemplDocMsg.Text = success;
            rulesFromRep.Text = "";
            nameTemplDoc.Text = "";
            nameTemplDocDown.Text = "<i class=\"material-icons\">insert_drive_file</i> " + file;
            btnTemplDocDelete.Visible = true;
            btnCancel.Visible = false;
            Response.Cookies["fileNameCompare"].Value = Server.UrlEncode("Temp/" + file);
            Response.Cookies["template"].Value = null;
            EnableCheck();
        }

        private void CheckDocShow(string file) // метода для показа данных на панели
        {
            panCheck.Visible = true; // панель с документом видима
            successUploadMsg.Text = success;
            nameCheckDoc.Text = "";
            btnFileDelete.Visible = true; // видима кнопка удаления
            nameDocCheckLoad.Text = "<i class=\"material-icons\">insert_drive_file</i> " + file;
            EnableCheck();
        } 
        protected void btn_rules_upload_Click(object sender, EventArgs e)
        {
            // удаление временных файлов в папке Temp
            Check.ClearFolder(HttpContext.Current.Server.MapPath(rulesFilePath + "Temp/"));

            panCompare.Visible = true;
            if (TemplateFileUploader.HasFile)
                try
                {
                    TemplateFileUploader.SaveAs(Server.MapPath(rulesFilePath + "Temp/") +
                         TemplateFileUploader.FileName); // сохранение шаблона документа во временной папке
                    successTemplDocMsg.Text = success;
                    rulesFromRep.Text = "";
                    nameTemplDoc.Text = ""; // имя документа не обозначено
                    string name = TemplateFileUploader.PostedFile.FileName;
                    if (name.Contains(@"\")) // если полный путь (для IE)
                        name = name.Remove(0, name.LastIndexOf(@"\")+1);
                    nameTemplDocDown.Text = "<i class=\"material-icons\">insert_drive_file</i> " + name;
                    btnTemplDocDelete.Visible = true; 
                    btnCancel.Visible = false;
                    Response.Cookies["fileNameCompare"].Value = Server.UrlEncode("Temp/" + name); // запись имени в Cookie
                    EnableCheck();
                }
                catch (Exception ex)
                {
                    errorTemplDoc.Text = error;
                    nameTemplDoc.Text = ex.Message.ToString();
                }
            else
            {
                panCompare.Visible = false;
            }
        }
        protected void del_file_Click(object sender, EventArgs e) // удаление документа
        {
            string sFileName = Server.UrlDecode(Request.Cookies["fileName"].Value); // получение имени из Cookie
            string sFilePath = uploadFilePath + sFileName; // полное имя файла
            FileInfo Dfile = new FileInfo(HttpContext.Current.Server.MapPath(sFilePath));
            File.Delete(Dfile.FullName); // удаление файла
            panCheck.Visible = false;
            Response.Cookies["fileName"].Value = ""; // обнуление значения в Cookie
            EnableCheck();
        }
        protected void del_rules_Click(object sender, EventArgs e) // удаление правил оформления
        {
            panCompare.Visible = false;
            EnableCheck();
        }
        protected void btn_check_Click(object sender, EventArgs e)
        {   // проверка на присутствие значений в файлах Cookie
            if (Request.Cookies["fileName"] != null && Request.Cookies["fileNameCompare"] != null)
            {   // имя проверяемого документа
                string fName = Server.HtmlEncode(Server.UrlDecode(Request.Cookies["fileName"].Value));
                // имя шаблона оформления
                string fComp = Server.HtmlEncode(Server.UrlDecode(Request.Cookies["fileNameCompare"].Value));
                // метод проверки документа
                Check.Do(fName, fComp,
                    HttpContext.Current.Server.MapPath(outDocsFilePath), // путь к папке OutDocs
                    HttpContext.Current.Server.MapPath(uploadFilePath),  // путь к папке Upload
                    HttpContext.Current.Server.MapPath(rulesFilePath));  // путь к папке RulesRepository
                pan.Visible = true; // панель с сылками на скачивание результирующих документов
            }
        }

        protected void opt_rules_Click(object sender, EventArgs e) // выбор правил оформления
        {
            // элементы управления видимы
            panCompare.Visible = true;
            btnTemplDocDelete.Visible = false;
            btnCancel.Visible = true; 
            Response.Cookies["fileNameCompare"].Value = Server.UrlEncode(dropDownListWorks.SelectedValue + ".docx");
            successTemplDocMsg.Text = "<h4><i class=\"material-icons\">done_all</i> Правила выбраны</h4>";
            rulesFromRep.Text = "<i class=\"material-icons\">insert_drive_file</i> " + dropDownListWorks.SelectedItem.Text;
            nameTemplDocDown.Text = "";
            nameTemplDoc.Text = "";
            EnableCheck();
        }

        private void EnableCheck()
        {
            // если панели с данными о документах невидимы
            if (panCompare.Visible == true && panCheck.Visible == true)
            {
                order.Text = "<h4>Теперь можно выполнить нормоконтроль.</h4>";
                btnCheck.Visible = true;
                pan.Visible = false;
            }
            else
            {
                order.Text = "<h4>Кажется, для проведения нормоконтроля чего-то не хватает.</h4>";
                btnCheck.Visible = false;
                pan.Visible = false;
            }
        }
        protected void btn_comment_Click(object sender, EventArgs e)
        {
            // скачивание выходного документа с комментариями
            string path = outDocsFilePath + Server.UrlDecode(Request.Cookies["fileName"].Value);
            Downloader.Download(Server.UrlDecode(Request.Cookies["fileName"].Value), path);
        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            // скачивание документа с исправленным форматированием
            string fileNameEdit = Server.UrlDecode(Request.Cookies["fileName"].Value).Replace(".docx", " - ComplianceAssessment.docx");
            string path = outDocsFilePath + fileNameEdit;
            Downloader.Download(fileNameEdit, path);
        }

        protected void btnOpenModal_Click(object sender, EventArgs e)
        {
            // регистрация JavaScript на стороне сервера для взаимодействия с модальным окном
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            // заголовок модального окна
            modTitle.Text = "<h4 class=\"modal-title\">"+ dropDownListWorks.SelectedItem + "</h4>";
            // запись в Cookie выбранного значения
            Response.Cookies["fileNameCompare"].Value = Server.UrlEncode(dropDownListWorks.SelectedValue + ".docx");
            // извлечение параметров для выбранных правил
            lblParams.Text = RetrievePropsClass.
                GetProperties(HttpContext.Current.Server.MapPath(rulesFilePath + dropDownListWorks.SelectedValue + ".docx"));
        }

        protected void nameTemplDocDown_Click(object sender, EventArgs e)
        {
            // скачивание врменного шаблона документа
            string path = rulesFilePath + Server.UrlDecode(Request.Cookies["fileNameCompare"].Value);
            Downloader.Download(Server.UrlDecode(Request.Cookies["fileNameCompare"].Value), path);
        }

        protected void btnTemplDocDelete_Click(object sender, EventArgs e)
        {
            // удаление шаблона документа
            string sFileName = Server.UrlDecode(Request.Cookies["fileNameCompare"].Value);
            string sFilePath = rulesFilePath + sFileName; // полное имя файла
            FileInfo Dfile = new FileInfo(HttpContext.Current.Server.MapPath(sFilePath));
            File.Delete(Dfile.FullName); // удаления файла из репозитория
            panCompare.Visible = false; // панель с правилами оформления невидима
            EnableCheck();
        }

        protected void rulesFromRep_Click(object sender, EventArgs e)
        {
            // скачивание правил оформления из репозитория
            string path = rulesFilePath + Server.UrlDecode(Request.Cookies["fileNameCompare"].Value);
            Downloader.Download(Server.UrlDecode(Request.Cookies["fileNameCompare"].Value), path);
        }

        protected void nameDocCheckLoad_Click(object sender, EventArgs e)
        {
            // скачивание исходного документа
            string path = uploadFilePath + Server.UrlDecode(Request.Cookies["fileName"].Value);
            Downloader.Download(Server.UrlDecode(Request.Cookies["fileName"].Value), path);
        }
        
    }
}