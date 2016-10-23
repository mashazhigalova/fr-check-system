<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" MasterPageFile="~/CompAssessMaster.Master" CodeBehind="Default.aspx.cs" Inherits="FRCCheckSystem.Default" MaintainScrollPositionOnPostback="true" %>

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
    <li class="dropdown">
        			<a href="#" class="dropdown-toggle" data-toggle="dropdown">Войти <b class="caret"></b></a>
        			<ul id="login-dp" class="dropdown-menu">
				<li>
					 <div class="row">
							<div class="col-md-12">
								<div class="input-group">
		                            <span class="input-group-addon">
			                            <i class="material-icons text-info">perm_identity</i>
		                            </span>
		                            <input id="login" runat="server" type="text" class="form-control" placeholder="Администратор"/>
	                            </div>
                                <div class="input-group">
                                <span class="input-group-addon">
			                            <i class="material-icons text-info">vpn_key</i>
		                            </span>
                                <input type="password" runat="server" class="form-control" id="inputPassword" placeholder="Пароль"/>
							    </div>
                            </div>
							<div class="bottom text-center">
                                <asp:Button ID="btnLogin" class="btn btn-info btn-raised" runat="server" Text="Войти" OnClick="btnLogin_Click" />
							</div>
					 </div>
				</li>
			</ul>
            </li>
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
        <asp:GridView ID="GridView1" CssClass="table table-striped table-hover" GridLines="None" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded">
            <Columns>
                <asp:BoundField DataField="Text" HeaderText="Имя файла"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" OnClick = "DownloadFile" CommandArgument = '<%# Eval("Value") %>' runat="server"><i class="material-icons text-info">file_download</i></asp:LinkButton>
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

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderEmail" runat="server">
    
</asp:Content>
