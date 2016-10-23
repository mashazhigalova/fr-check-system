<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="FRCCheckSystem.Admin" MasterPageFile="~/CompAssessMaster.Master" MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
    
    <script>
        $(document).ready(function()
        {
          //Handles menu drop down
          $('.dropdown-menu input').click(function (e) {
                e.stopPropagation();
                });
          });
    </script>
    <li><a href="Default.aspx"><i class="material-icons">exit_to_app</i>Выйти</a></li>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderNormDocs" runat="server">
<asp:LinkButton ID="btnNorm" ForeColor="#03a9f4" onclick="btnNorms_Click" runat="server"><i class="material-icons has-info">class</i> Нормативные документы</asp:LinkButton>
<div class="container">
<!-- Modal -->
<div class="modal fade" id="myModalNorms" role="dialog">
<div class="modal-dialog">
    <!-- Modal content-->
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4>Нормативные документы</h4>
    </div>
    <div class="modal-body">
        <div class="form-group is-fileinput is-focused has-info">
        <div class="input-group">
        <asp:FileUpload ID="FileUpload1" runat="server" />
                <input type="text" readonly="" class="form-control" placeholder="Файл не выбран..."/>
                <span class="input-group-btn input-group-sm">
                    <button type="button" class="btn btn-fab btn-fab-mini">
                    <i class="material-icons">attach_file</i>
                    </button>
                </span>
            </div>
        </div>
        <asp:Button ID="btnUpload" class="btn btn-info btn-raised" runat="server" Text="Загрузить" OnClick="UploadFile" />
        <hr />
        <asp:GridView ID="GridView1" CssClass="table table-striped table-hover" GridLines="None" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded">
            <Columns>
                <asp:BoundField DataField="Text" HeaderText="Имя файла"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" OnClick = "DownloadFile" CommandArgument = '<%# Eval("Value") %>' runat="server"><i class="material-icons text-info">file_download</i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID = "lnkDelete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile"><i class="material-icons text-danger">delete_forever</i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
    </div>
    </div>
</div>
</div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderEditRules" runat="server">
<asp:Button ID="btnEditList" runat="server" class="btn btn-sm btn-raised btn-danger" Text="Редактировать список" OnClick="btnEditList_Click"/>
<div class="container">
<!-- Modal -->
<div class="modal fade" id="myModalRules" role="dialog">
<div class="modal-dialog">
    <!-- Modal content-->
    <div class="modal-content">
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4>Правила оформления</h4>
    </div>
    <div class="modal-body">
        <div class="form-group is-fileinput is-focused has-info">
        <div class="input-group">
        <asp:FileUpload ID="FileUpload2" runat="server" />
                <input type="text" readonly="" class="form-control" placeholder="Файл не выбран..."/>
                <span class="input-group-btn input-group-sm">
                    <button type="button" class="btn btn-fab btn-fab-mini">
                    <i class="material-icons">attach_file</i>
                    </button>
                </span>
            </div>
        </div>
        <asp:Button ID="btnUploadRules" class="btn btn-info btn-raised" runat="server" Text="Загрузить" OnClick="btnUploadRules_Click" />
        <hr />
        <asp:GridView ID="GridView2" CssClass="table table-striped table-hover" GridLines="None" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded">
            <Columns>
                <asp:BoundField DataField="Text" HeaderText="Имя файла"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownloadRules" OnClick="lnkDownloadRules_Click" CommandArgument = '<%# Eval("Value") %>' runat="server"><i class="material-icons text-info">file_download</i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID = "lnkDeleteRules" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick="lnkDeleteRules_Click"><i class="material-icons text-danger">delete_forever</i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
    </div>
    </div>
</div>
</div>
</div>
</asp:Content>