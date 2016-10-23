<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="NewRulesEnter.aspx.cs" Inherits="FRCCheckSystem.NewRulesEnter" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script async="" src="http://cdn.api.twitter.com/1/urls/count.json?url=http%3A%2F%2Fdemos.creative-tim.com%2Fmaterial-design-kit%2Findex.html&amp;callback=jQuery11020026194078343686256_1460999136265&amp;_=1460999136266"></script>
	<meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css"/>
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    

	<link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png"/>
	<link rel="icon" type="image/png" href="assets/img/favicon.png"/>
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>

	<title>Нормоконтроль</title>

	<meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" name="viewport"/>
	<!--     Fonts and icons     -->
	<link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons"/>
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700"/>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css"/>

	<!-- CSS Files -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="assets/css/material-kit.css" rel="stylesheet" />
    <style type="text/css"></style>

</head>
<body>

<form id="form1" runat="server">
<!-- Navbar -->
<nav class="navbar navbar-fixed-top navbar-color-on-scroll navbar-transparent navbar-danger" role="navigation">
	<div class="container">
        <div class="navbar-header">
	    	<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navigation-index">
	        	<span class="sr-only">Toggle navigation</span>
	        	<span class="icon-bar"></span>
	        	<span class="icon-bar"></span>
	        	<span class="icon-bar"></span>
	    	</button>
            <asp:LinkButton ID="lbtnPrevPage" class="navbar-brand" runat="server" OnClick="lbtnPrevPage_Click"><i class="material-icons">arrow_back</i>Вернуться к проверке</asp:LinkButton>
	    </div>

	</div>
</nav>
<!-- End Navbar -->

<div class="wrapper">
	<div class="header header-filter" style="background-image: url(&quot;assets/img/pic3.jpg&quot;); background-size: cover; background-position: top center;">
		<div class="container">
            <div class="row"><br /><br /><br /><br /></div>
			<div class="row text-center">
					<div class="brand">
						<h1 class="title" style="color:white">Параметры оформления</h1>
                        <h4 style="color:white">Введите параметры форматирования и создайте собственный шаблон.</h4>
					</div>
			</div>
		</div>
	</div>
	<div class="main main-raised">  
       <div class="section">
           <div class="container">
               <div class="row">
                   <div class="col-md-3">
                   <h2>Стили</h2>
                       </div>
               </div>
                   <div class="row">
                       <div class="col-md-4">
                           <div class="panel-group" id="accordion">
                               <div class="panel panel-info">
                                    <div class="panel-heading">
                                      <div class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse0" class="text-warning">
                                        Обычный</a>
                                      </div>
                                    </div>
                                    <div id="collapse0" class="panel-collapse collapse">
                                      <div class="panel-body">
                                          <div class="row text-right">
                                              <div class="col-md-12">
                                                  <ul class="breadcrumb breadcrumb-info">
                                                      <li style="font-size:12px" class="active">Добавить/изменить параметры стиля</li>
                                              <asp:LinkButton ID="btnPlainText" OnClick="btnPlainText_Click" runat="server"><li class="material-icons text-danger">add_circle</li></asp:LinkButton>
                                                  </ul>
                                              </div>
                                          </div> 
                                          <div class="row">
                                              <div class="col-md-12">
                                              <asp:Label ID="lblPlainText" runat="server"></asp:Label>
                                            </div>
                                          </div>
                                      </div>
                                    </div>
                                  </div>
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                      <div class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1" class="text-warning">
                                        Заголовок 1</a>
                                      </div>
                                    </div>
                                    <div id="collapse1" class="panel-collapse collapse">
                                      <div class="panel-body">
                                          <div class="row text-right">
                                              <div class="col-md-12">
                                                  <ul class="breadcrumb breadcrumb-info">
                                                      <li style="font-size:12px" class="active">Добавить/изменить параметры стиля</li>
                                              <asp:LinkButton ID="btnHead1" OnClick="btnHead1_Click" runat="server"><li class="material-icons text-danger">add_circle</li></asp:LinkButton>
                                                  </ul>
                                              </div>
                                          </div> 
                                          <div class="row">
                                              <div class="col-md-12">
                                              <asp:Label ID="lblHead1" runat="server"></asp:Label>
                                            </div>
                                          </div>
                                      </div>
                                    </div>
                                  </div>
                                <div class="panel panel-info">
                                        <div class="panel-heading">
                                          <h4 class="panel-title">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse2" class="text-warning">
                                            Заголовок 2</a>
                                          </h4>
                                        </div>
                                        <div id="collapse2" class="panel-collapse collapse">
                                          <div class="panel-body">
                                            <div class="row text-right">
                                              <div class="col-md-12">
                                                  <ul class="breadcrumb breadcrumb-info">
                                                      <li style="font-size:12px" class="active">Добавить/изменить параметры стиля</li>
                                              <asp:LinkButton ID="btnHead2" OnClick="btnHead2_Click" runat="server"><li class="material-icons text-danger">add_circle</li></asp:LinkButton>
                                                  </ul>
                                              </div>
                                          </div> 
                                          <div class="row">
                                              <div class="col-md-12">
                                              <asp:Label ID="lblHead2" runat="server"></asp:Label>
                                            </div>
                                          </div>  
                                          </div>
                                        </div>
                                      </div>
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                      <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3" class="text-warning">
                                        Заголовок 3</a>
                                      </h4>
                                    </div>
                                    <div id="collapse3" class="panel-collapse collapse">
                                      <div class="panel-body">
                                          <div class="row text-right">
                                              <div class="col-md-12">
                                                  <ul class="breadcrumb breadcrumb-info">
                                                      <li style="font-size:12px" class="active">Добавить/изменить параметры стиля</li>
                                              <asp:LinkButton ID="btnHead3" OnClick="btnHead3_Click"  runat="server"><li class="material-icons text-danger">add_circle</li></asp:LinkButton>
                                                  </ul>
                                              </div>
                                          </div> 
                                          <div class="row">
                                              <div class="col-md-12">
                                              <asp:Label ID="lblHead3" runat="server"></asp:Label>
                                            </div>
                                          </div>
                                      </div>
                                    </div>
                                  </div>
                        </div>
                       </div>
                       <div class="col-md-8">
                           <asp:Panel ID="PanelStyle" runat="server" class="panel panel-info" Visible="false">
                                <div class="panel-heading">
                                  <h3 class="panel-title">Параметры стиля</h3>
                                </div>
                                <div class="panel-body">
                                        <div class="row">
                                        <div class="col-md-12">
                                        <ul class="breadcrumb breadcrumb-info">
                                          <li class="active" style="font-size:20px">Шрифт</li>
                                        </ul>
                                            </div>
                                            </div>
                                        <div class="row"><div class="col-md-2"><span class="label label-info">Начертание</span></div></div>

                                        <div class="row">
                                            <div class="col-md-3">
							                <div class="input-group">
								                    <span class="input-group-addon">
									                    <i class="material-icons">format_size</i>
								                    </span>
                                                        <div class="form-group label-floating is-empty">
                                                            <label class="control-label" for="fontSize">Размер</label>
                                                            <input class="form-control" id="fontSize" name="fontSize" type="number" min="0" max="150" step="any"/>
                                                            <p class="help-block">Пример: 12</p>
                                                          <span class="material-input"></span>
                                                        </div>
                                                </div>                                            
                                             </div>
                                        <div class="col-md-3">
                                            <br/>
                                        <div class="checkbox">
	                                        <label>
		                                        <input type="checkbox" name="cursive"/>
		                                        Курсив
	                                        </label>
                                        </div>
                                        </div>
                                        <div class="col-md-3">
                                            <br/>
                                        <div class="checkbox">
	                                        <label>
		                                        <input type="checkbox" name="underlined"/>
		                                        Подчеркнутый
	                                        </label>
                                        </div>
                                            </div>
                                    
                                        <div class="col-md-3">
                                            <br/>
                                        <div class="checkbox">
	                                        <label>
		                                        <input type="checkbox" name="bold"/>
		                                        Полужирный
	                                        </label>
                                        </div>
                                        </div>
                                            
                                        </div>
                                        <div class="row">
                                        <div class="col-md-3">
                                           <asp:DropDownList ID="dropDownListFonts" class="btn btn-sm btn-default btn-raised" runat="server"></asp:DropDownList>                                               
                                   
                                        </div>
                                            <div class="col-md-3">
                                            <asp:DropDownList ID="dropDownListColor" class="btn btn-sm btn-default btn-raised" runat="server"></asp:DropDownList>                                               
                                             </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                        <div class="col-md-12">
                                        <ul class="breadcrumb breadcrumb-info">
                                          <li class="active" style="font-size:20px">Абзац</li>
                                        </ul>
                                            </div>
                                            </div>
                                        <div class="row"><div class="col-md-2"><span class="label label-info">Отступы (см)</span></div></div>
                                        <div class="row">
                                            <div class="col-md-3">
							                <div class="input-group">
								                    <span class="input-group-addon">
									                    <i class="material-icons">format_indent_increase</i>
								                    </span>
                                                        <div class="form-group label-floating is-empty">
                                                            <label class="control-label" for="rightIndent">Справа</label>
                                                            <input class="form-control" id="rightIndent" name="rightIndent" 
                                                                type="number" min="-10" max="15" step="any"/>
                                                            <p class="help-block">Пример: 1,25</p>
                                                          <span class="material-input"></span>
                                                        </div>
                                                </div>
                                            </div>   
                                            <div class="col-md-3"> 
                                                <div class="input-group">
								                    <span class="input-group-addon">
									                    <i class="material-icons">format_indent_decrease</i>
								                    </span>
                                                        <div class="form-group label-floating is-empty">
                                                            <label class="control-label" for="leftIndent">Слева</label>
                                                            <input class="form-control" id="leftIndent" name="leftIndent" type="number" min="0" max="15" step="any"/>
                                                            <p class="help-block">Пример: 1,25</p>
                                                          <span class="material-input"></span>
                                                        </div>
                                                </div>
                                             </div>
                                            <div class="col-md-3">
                                                <div class="input-group">
								                    <span class="input-group-addon">
									                    <i class="material-icons">short_text</i>
								                    </span>
                                                        <div class="form-group label-floating is-empty">
                                                            <label class="control-label" for="firstIndent">Первая строка</label>
                                                            <input class="form-control" id="firstIndent" name="firstIndent" type="number" min="-10" max="15" step="any"/>
                                                            <p class="help-block">Пример: 1,25</p>
                                                          <span class="material-input"></span>
                                                        </div>
                                                </div>
                                                </div>
                                        </div>
                                        <div class="row"><br /><div class="col-md-2"><span class="label label-info">Интервалы (пт)</span></div></div>
                                        <div class="row">
                                            <div class="col-md-3">
							                <div class="input-group">
								                    <span class="input-group-addon">
                                            <i class="material-icons">vertical_align_bottom</i>

								                    </span>
                                                        <div class="form-group label-floating is-empty">
                                                            <label class="control-label" for="beforeSpace">Перед</label>
                                                            <input class="form-control" id="beforeSpace" name="beforeSpace" type="number" min="0" max="60" step="any"/>
                                                            <p class="help-block">Пример: 6</p>
                                                          <span class="material-input"></span>
                                                        </div>
                                                </div>
                                            </div>   
                                            <div class="col-md-3"> 
                                                <div class="input-group">
								                    <span class="input-group-addon">
                                                        <i class="material-icons">vertical_align_top</i>								            

								                    </span>
                                                        <div class="form-group label-floating is-empty">
                                                            <label class="control-label" for="afterSpace">После</label>
                                                            <input class="form-control" name="afterSpace" id="afterSpace" type="number" min="0" max="60" step="any"/>
                                                            <p class="help-block">Пример: 6</p>
                                                          <span class="material-input"></span>
                                                        </div>
                                                </div>
                                             </div>
                                            <div class="col-md-3">
                                                <div class="input-group">
								                    <span class="input-group-addon">
									                    <i class="material-icons">vertical_align_center</i>
								                    </span>
                                                        <div class="form-group label-floating is-empty">
                                                            <label class="control-label" for="btwSpace">Между</label>
                                                            <input class="form-control" id="btwSpace" name="btwSpace" type="number" min="0" max="60" step="any"/>
                                                            <p class="help-block">Пример: 1,5</p>
                                                          <span class="material-input"></span>
                                                        </div>
                                                </div>
                                                </div>
                                            
                                            <div class="col-md-3">
                                            <span>Выравнивание по</span>                                  
                                                <asp:DropDownList ID="dropDownListJust" class="btn btn-sm btn-default btn-raised" runat="server"></asp:DropDownList>                                               
                                                </div>
                                        </div>
                                        <div class="row">
                                            <br />
                                            <div class="col-md-2">
                                                   <asp:Button ID="btnAddStyle" runat="server" class="btn btn-sm btn-danger btn-raised" Text="Создать стиль" OnClick="btnAddStyle_Click"/>
                                            </div>
                                        </div>
                                </div>
                           </asp:Panel>
                       </div>
                   </div>
                    <div class="row">
                       <div class="col-md-7">
                       <h2>Параметры страницы</h2>
                           </div>
                   </div>
        <div class="row">
            <div class="col-md-12">
            <div class="panel panel-default">
            <div class="panel-body">
              <div class="row"><div class="col-md-8"><span class="label label-info">Поля (см)</span></div><div class="col-md-4"><span class="label label-info">Колонтитулы (см)</span></div></div>
                                <div class="row">
                                    <div class="col-md-2">
							        <div class="input-group">
								            <span class="input-group-addon">
									            <i class="material-icons">select_all</i>
								            </span>
                                                <div class="form-group label-floating is-empty">
                                                    <label class="control-label" for="rightMargin">Правое</label>
                                                    <input class="form-control" id="rightMargin" name="rightMargin" type="number" min="0" max="15" step="any"/>
                                                    <p class="help-block">Пример: 2.5</p>
                                                  <span class="material-input"></span>
                                                </div>
                                        </div>
                                    </div>   
                                    <div class="col-md-2"> 
                                        <div class="input-group">
								            <span class="input-group-addon">
									            <i class="material-icons">select_all</i>
								            </span>
                                                <div class="form-group label-floating is-empty">
                                                    <label class="control-label" for="leftMargin">Левое</label>
                                                    <input class="form-control" id="leftMargin" name="leftMargin" type="number" min="0" max="15" step="any"/>
                                                    <p class="help-block">Пример: 2,5</p>
                                                  <span class="material-input"></span>
                                                </div>
                                        </div>
                                     </div>
                                    <div class="col-md-2">
                                        <div class="input-group">
								            <span class="input-group-addon">
									            <i class="material-icons">select_all</i>
								            </span>
                                                <div class="form-group label-floating is-empty">
                                                    <label class="control-label" for="topMargin">Верхнее</label>
                                                    <input class="form-control" id="topMargin" name="topMargin" type="number" min="0" max="15" step="any"/>
                                                    <p class="help-block">Пример: 2,5</p>
                                                  <span class="material-input"></span>
                                                </div>
                                        </div>
                                        </div>
                                    <div class="col-md-2">
                                        <div class="input-group">
								            <span class="input-group-addon">
									            <i class="material-icons">select_all</i>
								            </span>
                                                <div class="form-group label-floating is-empty">
                                                    <label class="control-label" for="botMargin">Нижнее</label>
                                                    <input class="form-control" id="botMargin" name="botMargin" type="number" min="0" max="15" step="any"/>
                                                    <p class="help-block">Пример: 2,5</p>
                                                  <span class="material-input"></span>
                                                </div>
                                        </div>
                                        </div>
                                    
                                    <div class="col-md-2">
							        <div class="input-group">
								            <span class="input-group-addon">
									            <i class="material-icons">crop_free</i>
								            </span>
                                                <div class="form-group label-floating is-empty">
                                                    <label class="control-label" for="topCol">Верхний</label>
                                                    <input class="form-control" id="topCol" name="topCol" type="number" min="0" max="15" step="any"/>
                                                    <p class="help-block">Пример: 1,5</p>
                                                  <span class="material-input"></span>
                                                </div>
                                        </div>
                                    </div>   
                                    <div class="col-md-2"> 
                                        <div class="input-group">
								            <span class="input-group-addon">
									            <i class="material-icons">crop_free</i>
								            </span>
                                                <div class="form-group label-floating is-empty">
                                                    <label class="control-label" for="botCol">Нижний</label>
                                                    <input class="form-control" id="botCol" name="botCol" type="number" min="0" max="15" step="any"/>
                                                    <p class="help-block">Пример: 1,5</p>
                                                  <span class="material-input"></span>
                                                </div>
                                        </div>
                                     </div>
                                </div>
                <div class="row"><br />
                    <div class="col-md-2"><span class="label label-info">Номера страниц</span></div>
                </div>
                                <div class="row">
                                    <br />
                                    <div class="col-md-5">
                                        <br />
                                        <div class="togglebutton">
	                                        <label style="font-size:14px">
    	                                        <input type="checkbox" name="specCol"/>
		                                        <b>Особый колонтитул 1-ой страницы</b>
	                                        </label>
                                        </div>
                                        </div>
                                    <div class="col-md-2">
                                    <div>Положение</div>                                  
                                        <asp:DropDownList ID="dropDownListPlace" class="btn btn-sm btn-default btn-raised" runat="server"></asp:DropDownList>                                               
                                        </div>
                                    <div class="col-md-2 col-md-offset-1">
                                    <div>Выравнение по</div>                                  
                                        <asp:DropDownList ID="dropDownListNumJust" class="btn btn-sm btn-default btn-raised" runat="server"></asp:DropDownList>                                               
                                        </div>
                                </div>
            </div>
          </div>
                </div>
        </div>
               <div class="row text-center">
                   <asp:Button ID="btnCreateTemplate" runat="server" class="btn btn-lg btn-danger btn-raised" Text="Создать шаблон" OnClick="btnCreateTemplate_Click"/>
               <p>Созданный шаблон может быть использован для проверки документа</p>
               </div>
           </div>
       </div>   	
    </div> 
    <footer class="footer">
	    <div class="container">
	        <nav class="pull-left">
	            <ul>
                    <li>
                        
                    </li>
					<li>
						<a href = "mailto:ComplianceAssessmentSupport@gmail.com"><i class="material-icons">email</i>
                            Предложить свои правила оформления
						</a>
					</li>
	            </ul>
	        </nav>
	        <div class="copyright pull-right">
	            © 2016, made by Maria Zhigalova.
	        </div>
	    </div>
	</footer>
</div>         
</form>   

	<!--   Core JS Files   -->
    <script src="assets/js/jquery.min.js" type="text/javascript"></script>
    
    <script src="assets/js/bootstrap.min.js" type="text/javascript"></script>
	<script src="assets/js/material.min.js"></script>

	<!-- Control Center for Material Kit: activating the ripples, parallax effects, scripts from the example pages etc -->
	<script src="assets/js/material-kit.js" type="text/javascript"></script>

    <script>
        var header_height;
        var fixed_section;
        var floating = false;

        $().ready(function(){
            suggestions_distance = $("#suggestions").offset();
            pay_height = $('.fixed-section').outerHeight();

			$(window).on('scroll', materialKit.checkScrollForTransparentNavbar);

			materialKit.initSliders();
        });
    </script>
</body>

</html>
