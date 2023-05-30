<%@ Page Title="" Language="C#" MasterPageFile="~/Painel/Painel.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrador_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main id="js-page-content" role="main" class="page-content">
        <%--       <div class="row">
            <div class="col-lg-6 col-xl-3 order-lg-1 order-xl-1">
                <!-- profile summary -->
                <div class="card mb-g rounded-top">
                    <div class="row no-gutters row-grid">
                        <div class="col-12">
                            <div class="d-flex flex-column align-items-center justify-content-center p-4">
                                <img src="../images/Site/demo/avatars/avatar-admin_preto.png" class="rounded-circle shadow-2 img-thumbnail" alt="" />
                                <h5 class="mb-0 fw-700 text-center mt-3">
                                    <asp:Label ID="lblNome" runat="server" Text="Label"></asp:Label>
                                    <small class="text-muted mb-0">Toronto, Canada</small>
                                </h5>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="text-center py-3">
                                <h5 class="mb-0 fw-700">764
                                                    <small class="text-muted mb-0">Connections</small>
                                </h5>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="text-center py-3">
                                <h5 class="mb-0 fw-700">1,673
                                                    <small class="text-muted mb-0">Followers</small>
                                </h5>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-12 col-xl-6 order-lg-3 order-xl-2">
                <div class="card border mb-g">
                    <div class="card-body pl-4 pt-4 pr-4 pb-0">
                        <div class="d-flex flex-column">
                            <div class="border-0 flex-1 position-relative shadow-top">
                                <div class="pt-2 pb-1 pr-0 pl-0 rounded-0 position-relative" tabindex="-1">
                                    <span class="profile-image rounded-circle d-block position-absolute" style="background-image: url('img/demo/avatars/avatar-admin.png'); background-size: cover;"></span>
                                    <div class="pl-5 ml-5">
                                        <textarea class="form-control border-0 p-0 fs-xl" rows="4" placeholder="What's on your mind Codex?..."></textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="height-8 d-flex flex-row align-items-center flex-wrap flex-shrink-0">
                                <a href="javascript:void(0);" class="btn btn-icon fs-xl width-1 mr-1" data-toggle="tooltip" data-original-title="More options" data-placement="top">
                                    <i class="fal fa-ellipsis-v-alt color-fusion-300"></i>
                                </a>
                                <a href="javascript:void(0);" class="btn btn-icon fs-xl mr-1" data-toggle="tooltip" data-original-title="Attach files" data-placement="top">
                                    <i class="fal fa-paperclip color-fusion-300"></i>
                                </a>
                                <a href="javascript:void(0);" class="btn btn-icon fs-xl mr-1" data-toggle="tooltip" data-original-title="Insert photo" data-placement="top">
                                    <i class="fal fa-camera color-fusion-300"></i>
                                </a>
                                <button class="btn btn-info shadow-0 ml-auto">Post</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-6 col-xl-3 order-lg-2 order-xl-3">
                <!-- add : -->
                <div class="card mb-2">
                    <div class="card-body">
                        <a href="javascript:void(0);" class="d-flex flex-row align-items-center">
                            <div class='icon-stack display-3 flex-shrink-0'>
                                <i class="fal fa-circle icon-stack-3x opacity-100 color-primary-400"></i>
                                <i class="fas fa-graduation-cap icon-stack-1x opacity-100 color-primary-500"></i>
                            </div>
                            <div class="ml-3">
                                <strong>Add Qualifications
                                </strong>
                                <br>
                                Adding qualifications will help gain more clients
                            </div>
                        </a>
                    </div>
                </div>
                <div class="card mb-g">
                    <div class="card-body">
                        <a href="javascript:void(0);" class="d-flex flex-row align-items-center">
                            <div class='icon-stack display-3 flex-shrink-0'>
                                <i class="fal fa-circle icon-stack-3x opacity-100 color-warning-400"></i>
                                <i class="fas fa-handshake icon-stack-1x opacity-100 color-warning-500"></i>
                            </div>
                            <div class="ml-3">
                                <strong>Add Skills
                                </strong>
                                <br>
                                Gain more potential clients by adding skills
                            </div>
                        </a>
                    </div>
                </div>
            </div>

        </div>--%>

        <%--   <div class="row">
            <div class="col-xl-6 sortable-grid ui-sortable">
                <div class="subheader">
                    <h1 class="subheader-title">
                        <i class="subheader-icon fal fa-folder-open"></i>Caixa Entrada <span class="fw-300">Geral</span>
                        <small></small>
                        <hr />
                    </h1>
                </div>
                <div class="row">
            
                    <asp:Repeater ID="dlEmailEstatistica" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-6 col-xl-3">
                                <div class="p-4 <%# Eval("cor") %> rounded overflow-hidden position-relative text-white mb-g">
                                    <div class="">
                                        <h3 class="display-4 d-block l-h-n m-0 fw-500"><%# Eval("QTDE") %>
                                            <small class="m-0 l-h-n"><%# Eval("Situacao") %></small>
                                        </h3>
                                    </div>
                                    <i class="fal <%# Eval("icon") %> position-absolute pos-right pos-bottom opacity-15 mb-n1 mr-n1" style="font-size: 6rem"></i>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                   >
                </div>
            </div>

            <div class="col-xl-6 sortable-grid ui-sortable">
                <div class="subheader">
                    <h1 class="subheader-title">
                        <i class="subheader-icon fal fa-edit"></i>Cadastro <span class="fw-300"></span>
                        <small></small>
                        <hr />
                    </h1>
                </div>
                <div class="row">

                    <div class="col-sm-6 col-xl-3">
                        <div class="p-4 bg-primary-300 rounded overflow-hidden position-relative text-white mb-g">
                            <div class="">
                                <h3 class="display-4 d-block l-h-n m-0 fw-500">
                                    <a href="Relatorios/RelCadastros.aspx" style="color: white">
                                        <asp:Label ID="lblMensagem" runat="server" Text="Label"></asp:Label></a>
                                    <small class="m-0 l-h-n">Cadastros Atualizados</small>
                                </h3>
                            </div>
                            <i class="fal fa-user position-absolute pos-right pos-bottom opacity-15 mb-n1 mr-n1" style="font-size: 6rem"></i>
                        </div>
                    </div>
          
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-12 sortable-grid ui-sortable">
                <div class="subheader">
                    <h1 class="subheader-title">
                        <i class="fal fa-credit-card-front"></i> Notificações <span class="fw-300">E-mails</span>
                        <small></small>
                        <hr />
                    </h1>
                </div>
                <div class="row">
                    <asp:Repeater ID="dlNotificacao" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-6 col-xl-3">
                                <div class="p-4 <%# Eval("cor") %> rounded overflow-hidden position-relative text-white mb-g">
                                    <div class="">
                                        <h3 class="display-4 d-block l-h-n m-0 fw-500">
                                            <small class="m-0 l-h-n"><%# Eval("prazo") %> <BR />VERIFIQUE !!!
                                            </small>
                                        </h3>
                                    </div>
                                    <i class="fal <%# Eval("icon") %> position-absolute pos-right pos-bottom opacity-15 mb-n1 mr-n1" style="font-size: 6rem"></i>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </div>--%>


        <%--        <ol class="breadcrumb page-breadcrumb">
            <li class="breadcrumb-item"><a href="javascript:void(0);">SmartAdmin</a></li>
            <li class="breadcrumb-item">Application Intel</li>
            <li class="breadcrumb-item active">Analytics Dashboard</li>
            <li class="position-absolute pos-top pos-right d-none d-sm-block"><span class="js-get-date"></span></li>
        </ol>
        <div class="subheader">
            <h1 class="subheader-title">
                <i class='subheader-icon fal fa-chart-area'></i>Analytics <span class='fw-300'>Dashboard</span>
                <small></small>
            </h1>
            <div class="subheader-block d-lg-flex align-items-center">
                <div class="d-inline-flex flex-column justify-content-center mr-3">
                    <span class="fw-300 fs-xs d-block opacity-50">
                        <small>EXPENSES</small>
                    </span>
                    <span class="fw-500 fs-xl d-block color-primary-500">$47,000
                    </span>
                </div>
                <span class="sparklines hidden-lg-down" sparktype="bar" sparkbarcolor="#886ab5" sparkheight="32px" sparkbarwidth="5px" values="3,4,3,6,7,3,3,6,2,6,4"></span>
            </div>
            <div class="subheader-block d-lg-flex align-items-center border-faded border-right-0 border-top-0 border-bottom-0 ml-3 pl-3">
                <div class="d-inline-flex flex-column justify-content-center mr-3">
                    <span class="fw-300 fs-xs d-block opacity-50">
                        <small>MY PROFITS</small>
                    </span>
                    <span class="fw-500 fs-xl d-block color-danger-500">$38,500
                    </span>
                </div>
                <span class="sparklines hidden-lg-down" sparktype="bar" sparkbarcolor="#fe6bb0" sparkheight="32px" sparkbarwidth="5px" values="1,4,3,6,5,3,9,6,5,9,7"></span>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-12">
                <div id="panel-1" class="panel panel-locked" data-panel-lock="false" data-panel-close="false" data-panel-fullscreen="false" data-panel-collapsed="false" data-panel-color="false" data-panel-locked="false" data-panel-refresh="false" data-panel-reset="false">
                    <div class="panel-hdr">
                        <h2>Live Feeds
                        </h2>
                        <div class="panel-toolbar pr-3 align-self-end">
                            <ul id="demo_panel-tabs" class="nav nav-tabs border-bottom-0 nav-tabs-clean" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#tab_default-1" role="tab">Live Stats</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-toggle="tab" href="#tab_default-2" role="tab">Revenue</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content border-faded border-left-0 border-right-0 border-top-0">
                            <div class="row no-gutters">
                                <div class="col-lg-7 col-xl-8">
                                    <div class="position-relative">
                                        <div class="custom-control custom-switch position-absolute pos-top pos-left ml-5 mt-3 z-index-cloud">
                                            <input type="checkbox" class="custom-control-input" id="start_interval">
                                            <label class="custom-control-label" for="start_interval">Live Update</label>
                                        </div>
                                        <div id="updating-chart" style="height: 242px"></div>
                                    </div>
                                </div>
                                <div class="col-lg-5 col-xl-4 pl-lg-3">
                                    <div class="d-flex mt-2">
                                        My Tasks
                                                        <span class="d-inline-block ml-auto">130 / 500</span>
                                    </div>
                                    <div class="progress progress-sm mb-3">
                                        <div class="progress-bar bg-fusion-400" role="progressbar" style="width: 65%;" aria-valuenow="65" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <div class="d-flex">
                                        Transfered
                                                        <span class="d-inline-block ml-auto">440 TB</span>
                                    </div>
                                    <div class="progress progress-sm mb-3">
                                        <div class="progress-bar bg-success-500" role="progressbar" style="width: 34%;" aria-valuenow="34" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <div class="d-flex">
                                        Bugs Squashed
                                                        <span class="d-inline-block ml-auto">77%</span>
                                    </div>
                                    <div class="progress progress-sm mb-3">
                                        <div class="progress-bar bg-info-400" role="progressbar" style="width: 77%;" aria-valuenow="77" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <div class="d-flex">
                                        User Testing
                                                        <span class="d-inline-block ml-auto">7 days</span>
                                    </div>
                                    <div class="progress progress-sm mb-g">
                                        <div class="progress-bar bg-primary-300" role="progressbar" style="width: 84%;" aria-valuenow="84" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <div class="row no-gutters">
                                        <div class="col-6 pr-1">
                                            <a href="#" class="btn btn-default btn-block">Generate PDF</a>
                                        </div>
                                        <div class="col-6 pl-1">
                                            <a href="#" class="btn btn-default btn-block">Report a Bug</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content p-0">
                            <div class="row row-grid no-gutters">
                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-3">
                                    <div class="px-3 py-2 d-flex align-items-center">
                                        <div class="js-easy-pie-chart color-primary-300 position-relative d-inline-flex align-items-center justify-content-center" data-percent="75" data-piesize="50" data-linewidth="5" data-linecap="butt" data-scalelength="0">
                                            <div class="d-flex flex-column align-items-center justify-content-center position-absolute pos-left pos-right pos-top pos-bottom fw-300 fs-lg">
                                                <span class="js-percent d-block text-dark"></span>
                                            </div>
                                        </div>
                                        <span class="d-inline-block ml-2 text-muted">SERVER LOAD
                                                            <i class="fal fa-caret-up color-danger-500 ml-1"></i>
                                        </span>
                                        <div class="ml-auto d-inline-flex align-items-center">
                                            <div class="sparklines d-inline-flex" sparktype="line" sparkheight="30" sparkwidth="70" sparklinecolor="#886ab5" sparkfillcolor="false" sparklinewidth="1" values="5,6,5,3,8,6,9,7,4,2"></div>
                                            <div class="d-inline-flex flex-column small ml-2">
                                                <span class="d-inline-block badge badge-success opacity-50 text-center p-1 width-6">97%</span>
                                                <span class="d-inline-block badge bg-fusion-300 opacity-50 text-center p-1 width-6 mt-1">44%</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-3">
                                    <div class="px-3 py-2 d-flex align-items-center">
                                        <div class="js-easy-pie-chart color-success-500 position-relative d-inline-flex align-items-center justify-content-center" data-percent="79" data-piesize="50" data-linewidth="5" data-linecap="butt">
                                            <div class="d-flex flex-column align-items-center justify-content-center position-absolute pos-left pos-right pos-top pos-bottom fw-300 fs-lg">
                                                <span class="js-percent d-block text-dark"></span>
                                            </div>
                                        </div>
                                        <span class="d-inline-block ml-2 text-muted">DISK SPACE
                                                            <i class="fal fa-caret-down color-success-500 ml-1"></i>
                                        </span>
                                        <div class="ml-auto d-inline-flex align-items-center">
                                            <div class="sparklines d-inline-flex" sparktype="line" sparkheight="30" sparkwidth="70" sparklinecolor="#1dc9b7" sparkfillcolor="false" sparklinewidth="1" values="5,9,7,3,5,2,5,3,9,6"></div>
                                            <div class="d-inline-flex flex-column small ml-2">
                                                <span class="d-inline-block badge badge-info opacity-50 text-center p-1 width-6">76%</span>
                                                <span class="d-inline-block badge bg-warning-300 opacity-50 text-center p-1 width-6 mt-1">3%</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-3">
                                    <div class="px-3 py-2 d-flex align-items-center">
                                        <div class="js-easy-pie-chart color-info-500 position-relative d-inline-flex align-items-center justify-content-center" data-percent="23" data-piesize="50" data-linewidth="5" data-linecap="butt">
                                            <div class="d-flex flex-column align-items-center justify-content-center position-absolute pos-left pos-right pos-top pos-bottom fw-300 fs-lg">
                                                <span class="js-percent d-block text-dark"></span>
                                            </div>
                                        </div>
                                        <span class="d-inline-block ml-2 text-muted">DATA TTF
                                                            <i class="fal fa-caret-up color-success-500 ml-1"></i>
                                        </span>
                                        <div class="ml-auto d-inline-flex align-items-center">
                                            <div class="sparklines d-inline-flex" sparktype="line" sparkheight="30" sparkwidth="70" sparklinecolor="#51adf6" sparkfillcolor="false" sparklinewidth="1" values="3,5,2,5,3,9,6,5,9,7"></div>
                                            <div class="d-inline-flex flex-column small ml-2">
                                                <span class="d-inline-block badge bg-fusion-500 opacity-50 text-center p-1 width-6">10GB</span>
                                                <span class="d-inline-block badge bg-fusion-300 opacity-50 text-center p-1 width-6 mt-1">10%</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-3">
                                    <div class="px-3 py-2 d-flex align-items-center">
                                        <div class="js-easy-pie-chart color-fusion-500 position-relative d-inline-flex align-items-center justify-content-center" data-percent="36" data-piesize="50" data-linewidth="5" data-linecap="butt">
                                            <div class="d-flex flex-column align-items-center justify-content-center position-absolute pos-left pos-right pos-top pos-bottom fw-300 fs-lg">
                                                <span class="js-percent d-block text-dark"></span>
                                            </div>
                                        </div>
                                        <span class="d-inline-block ml-2 text-muted">TEMP.
                                                            <i class="fal fa-caret-down color-success-500 ml-1"></i>
                                        </span>
                                        <div class="ml-auto d-inline-flex align-items-center">
                                            <div class="sparklines d-inline-flex" sparktype="line" sparkheight="30" sparkwidth="70" sparklinecolor="#fd3995" sparkfillcolor="false" sparklinewidth="1" values="5,3,9,6,5,9,7,3,5,2"></div>
                                            <div class="d-inline-flex flex-column small ml-2">
                                                <span class="d-inline-block badge badge-danger opacity-50 text-center p-1 width-6">124</span>
                                                <span class="d-inline-block badge bg-info-300 opacity-50 text-center p-1 width-6 mt-1">40F</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-6">
                <div id="panel-2" class="panel" data-panel-fullscreen="false">
                    <div class="panel-hdr">
                        <h2>Smart Chat
                        </h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content p-0">
                            <div class="d-flex flex-column">
                                <div class="bg-subtlelight-fade custom-scroll" style="height: 244px">
                                    <div class="h-100">
                                        <!-- message -->
                                        <div class="d-flex flex-row px-3 pt-3 pb-2">
                                            <!-- profile photo : lazy loaded -->
                                            <span class="status status-danger">
                                                <span class="profile-image rounded-circle d-inline-block" style="background-image: url('img/demo/avatars/avatar-j.png')"></span>
                                            </span>
                                            <!-- profile photo end -->
                                            <div class="ml-3">
                                                <a href="javascript:void(0);" title="Lisa Hatchensen" class="d-block fw-700 text-dark">Lisa Hatchensen</a>
                                                Hey did you meet the new board of director? He's a bit of a geek if you ask me...anyway here is the report you requested. I am off to launch with Lisa and Andrew, you wanna join?
                                                                <!-- file download -->
                                                <div class="d-flex mt-3 flex-wrap">
                                                    <div class="btn-group mr-1 mt-1" role="group" aria-label="Button group with nested dropdown ">
                                                        <button type="button" class="btn btn-default btn-xs btn-block px-1 py-1 fw-500" data-action="toggle">
                                                            <span class="d-block text-truncate text-truncate-sm">
                                                                <i class="fal fa-file-pdf mr-1 color-danger-700"></i>Report-2013-demographic-repo
                                                            </span>
                                                        </button>
                                                        <div class="btn-group" role="group">
                                                            <button id="btnGroupDrop1" type="button" class="btn btn-default btn-xs dropdown-toggle px-2 js-waves-off" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></button>
                                                            <div class="dropdown-menu p-0 fs-xs" aria-labelledby="btnGroupDrop1">
                                                                <a class="dropdown-item px-3 py-2" href="#">Forward</a>
                                                                <a class="dropdown-item px-3 py-2" href="#">Open</a>
                                                                <a class="dropdown-item px-3 py-2" href="#">Delete</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="btn-group mr-1 mt-1" role="group" aria-label="Button group with nested dropdown ">
                                                        <button type="button" class="btn btn-default btn-xs btn-block px-1 py-1 fw-500" data-action="toggle">
                                                            <span class="d-block text-truncate text-truncate-sm">
                                                                <i class="fal fa-file-pdf mr-1 color-danger-700"></i>Bloodworks Patient 34124BA
                                                            </span>
                                                        </button>
                                                        <div class="btn-group" role="group">
                                                            <button id="btnGroupDrop2" type="button" class="btn btn-default btn-xs dropdown-toggle px-2 js-waves-off" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></button>
                                                            <div class="dropdown-menu p-0 fs-xs" aria-labelledby="btnGroupDrop2">
                                                                <a class="dropdown-item px-3 py-2" href="#">Forward</a>
                                                                <a class="dropdown-item px-3 py-2" href="#">Open</a>
                                                                <a class="dropdown-item px-3 py-2" href="#">Delete</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- file download end -->
                                            </div>
                                        </div>
                                        <!-- message end -->
                                        <!-- message reply -->
                                        <div class="d-flex flex-row px-3 pt-3 pb-2">
                                            <!-- profile photo : lazy loaded -->
                                            <span class="status status-danger">
                                                <span class="profile-image rounded-circle d-inline-block" style="background-image: url('img/demo/avatars/avatar-admin.png')"></span>
                                            </span>
                                            <!-- profile photo end -->
                                            <div class="ml-3">
                                                <a href="javascript:void(0);" title="Lisa Hatchensen" class="d-block fw-700 text-dark">Dr. Codex Lantern</a>
                                                Thanks for the file! You guys go ahead, I have to call some of my patients.
                                            </div>
                                        </div>
                                        <!-- message reply end -->
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-content border-faded border-left-0 border-right-0 border-bottom-0 bg-faded">
                            <textarea rows="3" class="form-control rounded-top border-bottom-left-radius-0 border-bottom-right-radius-0 border" placeholder="write a reply..."></textarea>
                            <div class="d-flex align-items-center py-2 px-2 bg-white border border-top-0 rounded-bottom bg-primary">
                                <div class="btn-group dropup">
                                    <button type="button" class="btn btn-icon fs-lg dropdown-toggle no-arrow" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <i class="fal fa-smile"></i>
                                    </button>
                                    <div class="dropdown-menu dropdown-menu-animated text-center rounded-pill overflow-hidden" style="width: 280px">
                                        <div class="px-1 py-0">
                                            <a href="javascript:void(0);" class="emoji emoji--like" data-toggle="tooltip" data-placement="top" title="" data-original-title="Like">
                                                <div class="emoji__hand">
                                                    <div class="emoji__thumb"></div>
                                                </div>
                                            </a>
                                            <a href="javascript:void(0);" class="emoji emoji--love" data-toggle="tooltip" data-placement="top" title="" data-original-title="Love">
                                                <div class="emoji__heart"></div>
                                            </a>
                                            <a href="javascript:void(0);" class="emoji emoji--haha" data-toggle="tooltip" data-placement="top" title="" data-original-title="Haha">
                                                <div class="emoji__face">
                                                    <div class="emoji__eyes"></div>
                                                    <div class="emoji__mouth">
                                                        <div class="emoji__tongue"></div>
                                                    </div>
                                                </div>
                                            </a>
                                            <a href="javascript:void(0);" class="emoji emoji--yay" data-toggle="tooltip" data-placement="top" title="" data-original-title="Yay">
                                                <div class="emoji__face">
                                                    <div class="emoji__eyebrows"></div>
                                                    <div class="emoji__mouth"></div>
                                                </div>
                                            </a>
                                            <a href="javascript:void(0);" class="emoji emoji--wow" data-toggle="tooltip" data-placement="top" title="" data-original-title="Wow">
                                                <div class="emoji__face">
                                                    <div class="emoji__eyebrows"></div>
                                                    <div class="emoji__eyes"></div>
                                                    <div class="emoji__mouth"></div>
                                                </div>
                                            </a>
                                            <a href="javascript:void(0);" class="emoji emoji--sad" data-toggle="tooltip" data-placement="top" title="" data-original-title="Sad">
                                                <div class="emoji__face">
                                                    <div class="emoji__eyebrows"></div>
                                                    <div class="emoji__eyes"></div>
                                                    <div class="emoji__mouth"></div>
                                                </div>
                                            </a>
                                            <a href="javascript:void(0);" class="emoji emoji--angry" data-toggle="tooltip" data-placement="top" title="" data-original-title="Angry">
                                                <div class="emoji__face">
                                                    <div class="emoji__eyebrows"></div>
                                                    <div class="emoji__eyes"></div>
                                                    <div class="emoji__mouth"></div>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <button type="button" class="btn btn-icon fs-lg">
                                    <i class="fal fa-paperclip"></i>
                                </button>
                                <div class="custom-control custom-checkbox custom-control-inline ml-auto hidden-sm-down">
                                    <input type="checkbox" class="custom-control-input" id="defaultInline1">
                                    <label class="custom-control-label" for="defaultInline1">Press <strong>ENTER</strong> to send</label>
                                </div>
                                <button class="btn btn-primary btn-sm ml-auto ml-sm-0">
                                    Reply
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="panel-3" class="panel">
                    <div class="panel-hdr">
                        <h2 class="js-get-date"></h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <div id="calendar"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-12">
                <div id="panel-4" class="panel">
                    <div class="panel-hdr">
                        <h2>Bird's Eyes</h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content jqvmap-bg-ocean p-0" style="height: 330px;">
                            <div id="vector-map" class="w-100 h-100 p-4"></div>
                        </div>
                        <div class="panel-content jqvmap-bg-ocean">
                            <div class="d-flex align-items-center">
                                <img class="d-inline-block js-jqvmap-flag mr-3 border-faded" alt="flag" src="https://lipis.github.io/flag-icon-css/flags/4x3/us.svg" style="width: 55px; height: auto;">
                                <h4 class="d-inline-block fw-300 m-0 text-muted fs-lg">Showcasing information:
                                                    <small class="js-jqvmap-country mb-0 fw-500 text-dark">United States of America - $3,760,125.00</small>
                                </h4>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="panel-5" class="panel">
                    <div class="panel-hdr">
                        <h2>Notícias</h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content">
                            <h5>Mais Visualizadas
                            </h5>
                            <div id="flotBar1" style="width: 100%; height: 160px;"></div>
                        </div>
                    </div>
                </div>
                <div id="panel-6" class="panel">
                    <div class="panel-hdr">
                        <h2>Notícias </h2>
                    </div>
                    <div class="panel-container show">
                        <div class="panel-content p-0 mb-g">
                            <div class="alert alert-success alert-dismissible fade show border-faded border-left-0 border-right-0 border-top-0 rounded-0 m-0" role="alert">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true"><i class="fal fa-times"></i></span>
                                </button>
                                <strong><span class="js-get-date"></span>
                                    <br />
                                    (mais visualizadas)</strong>
                            </div>
                        </div>
                        <div class="panel-content">
                            <div class="row  mb-g">
                                <div class="col-md-6 d-flex align-items-center">
                                    <div id="flotPie" class="w-100" style="height: 250px"></div>
                                </div>
                                <div class="col-md-6 col-lg-5 mr-lg-auto">
                                    <div class="d-flex mt-2 mb-1 fs-xs text-primary">
                                        Current Usage
                                    </div>
                                    <div class="progress progress-xs mb-3">
                                        <div class="progress-bar" role="progressbar" style="width: 70%;" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <div class="d-flex mt-2 mb-1 fs-xs text-info">
                                        Net Usage
                                    </div>
                                    <div class="progress progress-xs mb-3">
                                        <div class="progress-bar bg-info-500" role="progressbar" style="width: 30%;" aria-valuenow="30" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <div class="d-flex mt-2 mb-1 fs-xs text-warning">
                                        Users blocked
                                    </div>
                                    <div class="progress progress-xs mb-3">
                                        <div class="progress-bar bg-warning-500" role="progressbar" style="width: 40%;" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <div class="d-flex mt-2 mb-1 fs-xs text-danger">
                                        Custom cases
                                    </div>
                                    <div class="progress progress-xs mb-3">
                                        <div class="progress-bar bg-danger-500" role="progressbar" style="width: 15%;" aria-valuenow="15" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <div class="d-flex mt-2 mb-1 fs-xs text-success">
                                        Test logs
                                    </div>
                                    <div class="progress progress-xs mb-3">
                                        <div class="progress-bar bg-success-500" role="progressbar" style="width: 25%;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                    <div class="d-flex mt-2 mb-1 fs-xs text-dark">
                                        Uptime records
                                    </div>
                                    <div class="progress progress-xs mb-3">
                                        <div class="progress-bar bg-fusion-500" role="progressbar" style="width: 10%;" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
    </main>
</asp:Content>

