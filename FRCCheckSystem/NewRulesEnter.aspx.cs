using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ComplianceAssessment;

namespace FRCCheckSystem
{
    public partial class NewRulesEnter : System.Web.UI.Page
    {
        DocDesc desc;
        StyleDesc plain = new StyleDesc(); // описание обычного стиля
        StyleDesc head1 = new StyleDesc(); // описание Заголовка 1
        StyleDesc head2 = new StyleDesc(); // описание Заголовка 2
        StyleDesc head3 = new StyleDesc(); // описание Заголовка 3
        Dictionary<string, string> colors = new Dictionary<string, string> // цвет шрифта
            { 
                { "000000", "черный" },
                { "808080", "серый"},
                { "ff0000", "красный"},
                { "0000ff", "синий"},
                { "ffff00", "желтый"},
                { "00ff00", "зеленый"},
            };

        Dictionary<string, string> justificationDict = new Dictionary<string, string> // выравнивание текста
        {
            ["Both"] = "ширине",
            ["Left"] = "левому краю",
            ["Right"] = "правому краю",
            ["Center"] = "центру"
        };

        Dictionary<string, string> placeDict = new Dictionary<string, string> // положение номера на странице
        {
            ["Bottom"] = "внизу страницы",
            ["Top"] = "вверху страницы"
        };
        private void DropListFill() // заполнение выпадающих списков
        {
            List<string> fonts = new List<string> { "Times New Roman", "Arial", "Courier New", "Calibri" };
            List<ListItem> fName = new List<ListItem>(); // названия шрифтов
            foreach (string f in fonts)
            {
                fName.Add(new ListItem(f, f));
            }
            dropDownListFonts.DataSource = fName; // заполнить выпадающий список названиями шрифтов
            dropDownListFonts.DataBind();            
            List<ListItem> cName = new List<ListItem>(); // цвета шрифтов
            foreach (var c in colors)
            {
                cName.Add(new ListItem(c.Value, c.Key));
            }
            dropDownListColor.DataSource = cName; // заполнить выпадающий список
            dropDownListColor.DataBind();
            List<ListItem> jName = new List<ListItem>(); // выравнивание
            foreach (var j in justificationDict)
            {
                jName.Add(new ListItem(j.Value, j.Key));
            }
            dropDownListJust.DataSource = jName; // заполнить выпадающий список (абзац)
            dropDownListJust.DataBind();
            dropDownListNumJust.DataSource = jName; // заполнить выпадающий список (нумерация)
            dropDownListNumJust.DataBind();
            
            List<ListItem> place = new List<ListItem>(); // положение на странице
            foreach (var p in placeDict)
            {
                place.Add(new ListItem(p.Value, p.Key));
            }
            dropDownListPlace.DataSource = place; // заполнить выпадающий список
            dropDownListPlace.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e) // открытие страницы
        {
            if (!IsPostBack)
            {
                Session.Clear(); // очистить сессию
                Response.Cookies["template"].Value = ""; // имя шаблона не назначено
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
                DropListFill();
            }
        }
        private bool BoolVal(string val) // для булевых свойств
        {
            if (val == "on") // если в разметке есть On
                return true;
            else return false;
        }

        private double DoubleVal(string val) // для числовых значений
        {
            if (val.Contains("."))
                val = val.Replace(".", ",");
            double result;
            if (double.TryParse(val, out result)) // обраюотка ситуации, когда введено некорректное значение
                return result;
            else return -100;
        }
        protected void btnAddStyle_Click(object sender, EventArgs e) // добавить стиль
        {
            switch (Request.Cookies["heading"].Value)
            {
                case "0": // для обычного стиля
                    lblPlainText.Text = StyleDescription(ref plain); // добавить описание стиля
                    plain.LevelSt = 1;
                    Session["plain"] = plain; // записать переменную стиля в сессию
                    PanelStyle.Visible = false;
                    break;
                case "1": // для Заголовка 1
                    lblHead1.Text = StyleDescription(ref head1); // добавить описание стиля
                    head1.LevelSt = 2;
                    PanelStyle.Visible = false;
                    Session["head1"] = head1; // записать переменную стиля в сессию
                    break;
                case "2": // для Заголовка 2
                    lblHead2.Text = StyleDescription(ref head2); // добавить описание стиля
                    head2.LevelSt = 3;
                    PanelStyle.Visible = false;
                    Session["head2"] = head2; // записать переменную стиля в сессию
                    break;
                case "3": // для Заголовка 3
                    lblHead3.Text = StyleDescription(ref head3); // добавить описание стиля 
                    head3.LevelSt = 4;
                    PanelStyle.Visible = false;
                    Session["head3"] = head3; // записать переменную стиля в сессию
                    break;
            }

        }

        private string StyleDescription(ref StyleDesc st) // описание стиля
        {
            // присваивание значений интервалам
            st.AfterSpace = DoubleVal(Request.Form["afterSpace"]);
            st.BeforeSpace = DoubleVal(Request.Form["beforeSpace"]);
            st.BtwSapce = DoubleVal(Request.Form["btwSpace"]);
            string intervals = "<p>▪   Интервалы:"+ 
                ((st.AfterSpace != -100) ? " после " + st.AfterSpace + " пт;" : "") + 
                ((st.BeforeSpace!=-100)? " перед - " + st.BeforeSpace + " пт;":"")+
                ((st.BtwSapce != -100) ? " между - " + st.BtwSapce + "</p>" : "");
            // присваивание значений отступам
            st.LeftIndent = DoubleVal(Request.Form["leftIndent"]);
            st.RigthtIndent = DoubleVal(Request.Form["rightIndent"]);
            st.FirstLineIndent = DoubleVal(Request.Form["firstIndent"]);
            string indents = "<p>▪   Отступы:"+ 
            ((st.RigthtIndent!=-100) ? " справа " + st.RigthtIndent + " см;":"") +
            ((st.LeftIndent != -100) ? " слева " + st.LeftIndent + " см;" : "")+
            ((st.FirstLineIndent != -100) ? " первой строки " + st.FirstLineIndent + " см.</p>":"");
            // присваивание значений настройкам шрифта
            st.Bold = BoolVal(Request.Form["bold"]);
            st.Color = colors.First(p => p.Value == dropDownListColor.SelectedValue).Key;
            st.FontSize = DoubleVal(Request.Form["fontSize"]);
            st.Cursive = BoolVal(Request.Form["cursive"]);
            st.Font = dropDownListFonts.SelectedValue;
            st.JustPar = justificationDict.First(j => j.Value == dropDownListJust.SelectedValue).Key;
            st.Underlined = BoolVal(Request.Form["underlined"]);
            // проверить, отмечены ли чекбоксы
            string view = ((st.Bold == true) ? " полужирный " : "")
             + ((st.Cursive == true) ? " курсив " : "") + ((st.Underlined == true) ? " подчеркнутый " : "");
            // добавить строку с начертанием
            if (view != "")
                view = "▪   Начертание: " + view;
            return
                "<div class=\"text-info\">Параметры абзаца</div>" + intervals + indents+ "<p>▪   Выравнивание по " +
            dropDownListJust.SelectedItem + "</p>" 
            + "<div class=\"text-info\">Параметры шрифта</div><p>▪   Название шрифта: " + st.Font + "; цвет - " + dropDownListColor.SelectedItem 
            + ((st.FontSize!=-100) ? "; размер: " + st.FontSize + " пт":"")+".</p><p>"+ view + "</p>";
        }
        protected void btnHead1_Click(object sender, EventArgs e)
        {
            PanelStyle.Visible = true; // панель с заголовком 1 становится видима
            Response.Cookies["heading"].Value = "1";
        }

        protected void btnCreateTemplate_Click(object sender, EventArgs e) // создание шаблона документа
        {
            // извлечение переменных их сессии
            plain = (StyleDesc)Session["plain"]; // обычного текста
            head1 = (StyleDesc)Session["head1"]; // Заголовка 1
            head2 = (StyleDesc)Session["head2"]; // Заголовка 2
            head3 = (StyleDesc)Session["head3"]; // Заголовка 3
            Dictionary<int, StyleDesc> styles = new Dictionary<int, StyleDesc>(); // словарь со стилями документа
            if (plain != null) styles.Add(plain.LevelSt, plain); // добавить в список стилей, если не null
            if (head1 != null) styles.Add(head1.LevelSt, head1); 
            if (head2 != null) styles.Add(head2.LevelSt, head2); 
            if (head3 != null) styles.Add(head3.LevelSt, head3); 

            desc = new DocDesc(); // описание докумнента
            desc.ColBot = DoubleVal(Request.Form["botCol"]); // нижний колонтитул
            desc.ColTop = DoubleVal(Request.Form["topCol"]); // верхний колонтитул
            desc.Margins = new Dictionary<string, double> { // словарь полей страницы
                { "rightMargin", DoubleVal(Request.Form["rightMargin"])}, // правое поле
                { "leftMargin", DoubleVal(Request.Form["leftMargin"])}, // левое поле 
                { "topMargin", DoubleVal(Request.Form["topMargin"])}, // верхнее поле
                { "botMargin", DoubleVal(Request.Form["botMargin"])} // нижнее поле
            };
            // выравнивание номера на странице
            desc.NumJust = justificationDict.First(nj => nj.Value == dropDownListNumJust.SelectedValue).Key;
            // положение номера на странице
            desc.Place = placeDict.First(p => p.Value == dropDownListPlace.SelectedValue).Key;
            // специальный колонтитул первой страницы
            desc.SpecCol = BoolVal(Request.Form["specCol"]);
            // функция добавления шаблона документа
            DocDesc.CreateTemplate(styles, desc, HttpContext.Current.Server.MapPath("~/App_Data/"));
            Response.Cookies["template"].Value = "template.docx";
            // возвращение на страницу проверки документа
            object refUrl = ViewState["RefUrl"];
            if (refUrl != null)
                Response.Redirect((string)refUrl);
        }

        protected void btnPlainText_Click(object sender, EventArgs e)
        {
            PanelStyle.Visible = true;
            Response.Cookies["heading"].Value = "0"; // если выбран обычный стиль
        }

        protected void btnHead3_Click(object sender, EventArgs e)
        {
            PanelStyle.Visible = true;
            Response.Cookies["heading"].Value = "3"; // если выбран Заголовок 3
        }

        protected void btnHead2_Click(object sender, EventArgs e)
        {
            PanelStyle.Visible = true;
            Response.Cookies["heading"].Value = "2"; // если выбран Заголовок 2
        }

        protected void lbtnPrevPage_Click(object sender, EventArgs e)
        {
            // переход на предшествующую страницу
            object refUrl = ViewState["RefUrl"];
            if (refUrl != null)
                Response.Redirect((string)refUrl);
        }
    }
    
}