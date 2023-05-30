<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>


<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        //EnviarEmailNotificacao();
        Mapeamento();
    }

    //void EnviarEmailNotificacao()
    //{
    //    string horaIni = "09:00:00";
    //    string horaFim = "10:00:00";

    //    DateTime data = DateTime.Now;
    //    string horaAgora = data.ToLongTimeString();

    //    if (horaAgora.CompareTo(horaIni) > -1 && horaAgora.CompareTo(horaFim) < 1)
    //    //if (int.Parse(horaAgora) >= int.Parse(horaIni) && int.Parse(horaAgora) <= int.Parse(horaFim))
    //    {
    //        /* Chamando pagina para o envio dos e-mails de notificação */
    //        RouteTable.Routes.MapPageRoute("EnvioEmailNotificacao", "EnvioEmailNotificacao", "~/EnviaEmailNotificacao.aspx");
    //    }
    //}

    void Mapeamento()
    {


        /* Site */
        RouteTable.Routes.MapPageRoute("Inicio", "Inicio", "~/Default.aspx");
        RouteTable.Routes.MapPageRoute("Errorpage", "Errorpage/{Param}", "~/ErrorPage.aspx");
        RouteTable.Routes.MapPageRoute("EsqueceuSenha", "EsqueceuSenha", "~/EsqueceuSenha.aspx");

        /* Area do Painel */
        RouteTable.Routes.MapPageRoute("PnlAlerta", "Painel/Alerta/{Param}", "~/Painel/Alerta.aspx");
        RouteTable.Routes.MapPageRoute("PnlInicio", "Painel/Inicio", "~/Painel/Default.aspx");

        /* Area do Painel - Administracao */
        RouteTable.Routes.MapPageRoute("AdmSenha", "Painel/Administracao/AlterarSenha", "~/Painel/Administracao/Senha.aspx");
        RouteTable.Routes.MapPageRoute("AdmConfig", "Painel/Administracao/Configuracao", "~/Painel/Administracao/Configuracao.aspx");
        RouteTable.Routes.MapPageRoute("AdmGrupo", "Painel/Administracao/Grupo", "~/Painel/Administracao/Grupo.aspx");
        RouteTable.Routes.MapPageRoute("AdmGrupoEdita", "Painel/Administracao/GrupoEdita/{Param}", "~/Painel/Administracao/GrupoEdita.aspx");
        RouteTable.Routes.MapPageRoute("AdmUsuarios", "Painel/Administracao/Usuarios", "~/Painel/Administracao/Usuario.aspx");
        RouteTable.Routes.MapPageRoute("AdmPermissoes", "Painel/Administracao/Permissoes/{UsuarioWebID}", "~/Painel/Administracao/Permissoes.aspx");


        /* Area do Painel - Galeria */
        RouteTable.Routes.MapPageRoute("GalFotos",          "Painel/Galeria/Fotos", "~/Painel/Galeria/Fotos.aspx");
        RouteTable.Routes.MapPageRoute("GalFotosEdita",     "Painel/Galeria/Fotos/{Param}", "~/Painel/Galeria/FotosEdita.aspx");
        RouteTable.Routes.MapPageRoute("GalFotosTipo",      "Painel/Galeria/TipoGaleria", "~/Painel/Galeria/FotosTipo.aspx");
        RouteTable.Routes.MapPageRoute("GalFotosUpload",    "Painel/Galeria/Upload", "~/Painel/Galeria/FotosUpload.aspx");
        RouteTable.Routes.MapPageRoute("GalYoutube",        "Painel/Galeria/Youtube", "~/Painel/Galeria/Youtube.aspx");
        RouteTable.Routes.MapPageRoute("GalYoutubeEdita",   "Painel/Galeria/Youtube/{Param}", "~/Painel/Galeria/YoutubeEdita.aspx");


        /* Area do Painel - Noticias */
        RouteTable.Routes.MapPageRoute("NotAdministracao", "Painel/Noticias/Administracao", "~/Painel/Noticias/Administracao.aspx");
        RouteTable.Routes.MapPageRoute("NotAdministracaoVizualizar", "Painel/Noticias/AdministracaoVizualizar/{Param}", "~/Painel/Noticias/AdministracaoVizualizar.aspx");
        RouteTable.Routes.MapPageRoute("NotCategoria", "Painel/Noticias/Categoria/{Param}", "~/Painel/Noticias/Categoria.aspx");
        RouteTable.Routes.MapPageRoute("NotCategoriaEdita", "Painel/Noticias/CategoriaEdita/{Param}", "~/Painel/Noticias/CategoriaEdita.aspx");
        RouteTable.Routes.MapPageRoute("NotDepartamento", "Painel/Noticias/Departamento", "~/Painel/Noticias/Departamento.aspx");
        RouteTable.Routes.MapPageRoute("NotDepartamentoEdita", "Painel/Noticias/Departamento/{Param}", "~/Painel/Noticias/DepartamentoEdita.aspx");
        RouteTable.Routes.MapPageRoute("NotPublicacao", "Painel/Noticias/Publicacao", "~/Painel/Noticias/Publicacao.aspx");
        RouteTable.Routes.MapPageRoute("NotPublicacaoP", "Painel/Noticias/Publicacao/{Param}", "~/Painel/Noticias/Publicacao.aspx");


        /* Area do Painel - Modulos */

        RouteTable.Routes.MapPageRoute("ModBanner",                 "Painel/Modulos/Banner", "~/Painel/Modulos/Banner.aspx");
        RouteTable.Routes.MapPageRoute("ModBannerEdita",            "Painel/Modulos/BannerEdita/{Param}", "~/Painel/Modulos/BannerEdita.aspx");
        RouteTable.Routes.MapPageRoute("ModBannerItem",             "Painel/Modulos/BannerItem/{Param}", "~/Painel/Modulos/BannerItem.aspx");
        RouteTable.Routes.MapPageRoute("ModBannerItemEdita",        "Painel/Modulos/BannerItemEdita/{Param}", "~/Painel/Modulos/BannerItemEdita.aspx");
        RouteTable.Routes.MapPageRoute("ModComunicado",             "Painel/Modulos/Comunicado", "~/Painel/Modulos/Comunicado.aspx");
        RouteTable.Routes.MapPageRoute("ModConvenios",              "Painel/Modulos/Convenios", "~/Painel/Modulos/Convenios.aspx");
        RouteTable.Routes.MapPageRoute("ModConveniosEdita",         "Painel/Modulos/Convenios/{Param}", "~/Painel/Modulos/ConveniosEdita.aspx");
        RouteTable.Routes.MapPageRoute("ModDiretoria",              "Painel/Modulos/Diretoria", "~/Painel/Modulos/Diretoria.aspx");
        RouteTable.Routes.MapPageRoute("ModDiretoriaEdita",         "Painel/Modulos/DiretoriaEdita/{Param}", "~/Painel/Modulos/DiretoriaEditar.aspx");
        RouteTable.Routes.MapPageRoute("ModDuvidas",                "Painel/Modulos/Duvidas", "~/Painel/Modulos/Duvidas.aspx");
        RouteTable.Routes.MapPageRoute("ModDuvidasEdita",           "Painel/Modulos/Duvidas/{Param}", "~/Painel/Modulos/DuvidasEdita.aspx");
        RouteTable.Routes.MapPageRoute("ModEstatuto",               "Painel/Modulos/Estatuto", "~/Painel/Modulos/Estatuto.aspx");
        RouteTable.Routes.MapPageRoute("ModEstatutoEdita",          "Painel/Modulos/EstatutoEdita/{Param}", "~/Painel/Modulos/EstatutoEdita.aspx");
        RouteTable.Routes.MapPageRoute("ModHistoria",               "Painel/Modulos/Historia", "~/Painel/Modulos/Historia.aspx");
        RouteTable.Routes.MapPageRoute("ModHistoriaEdita",          "Painel/Modulos/HistoriaEdita/{Param}", "~/Painel/Modulos/HistoriaEdita.aspx");
        RouteTable.Routes.MapPageRoute("ModLinksUteis",             "Painel/Modulos/LinksUteis", "~/Painel/Modulos/LinksUteis.aspx");
        RouteTable.Routes.MapPageRoute("ModLinksUteisEdita",        "Painel/Modulos/LinksUteis/{Param}", "~/Painel/Modulos/LinksUteisEdita.aspx");
        RouteTable.Routes.MapPageRoute("ModPublicacoes",            "Painel/Modulos/Publicacoes", "~/Painel/Modulos/Publicacoes.aspx");
        RouteTable.Routes.MapPageRoute("ModPublicacoesEdita",       "Painel/Modulos/PublicacoesEdita/{Param}", "~/Painel/Modulos/PublicacoesEdita.aspx");
        RouteTable.Routes.MapPageRoute("ModPublicacoesItem",        "Painel/Modulos/PublicacoesItem/{Param}", "~/Painel/Modulos/PublicacoesItem.aspx");
        RouteTable.Routes.MapPageRoute("ModPublicacoesItemEdita",   "Painel/Modulos/PublicacoesItemEdita/{Param}", "~/Painel/Modulos/PublicacoesItemEdita.aspx");
        RouteTable.Routes.MapPageRoute("ModRegistroSindical",       "Painel/Modulos/RegistroSindical", "~/Painel/Modulos/RegistroSindical.aspx");


        /* Area do Painel - Sorteio */
        RouteTable.Routes.MapPageRoute("Sorteio",                   "Painel/Sorteio/Sorteio", "~/Painel/Sorteio/Sorteio.aspx");
        RouteTable.Routes.MapPageRoute("SorteioEdita",              "Painel/Sorteio/SorteioEdita/{Param}", "~/Painel/Sorteio/SorteioEdita.aspx");

        RouteTable.Routes.MapPageRoute("SorteioPremio",             "Painel/Sorteio/Premio/{Param}", "~/Painel/Sorteio/Premio.aspx");
        RouteTable.Routes.MapPageRoute("SorteioPremioEdita",        "Painel/Sorteio/PremioEdita/{Param}", "~/Painel/Sorteio/PremioEdita.aspx");

        RouteTable.Routes.MapPageRoute("SorteioParticipantes",      "Painel/Sorteio/Participantes/{Param}", "~/Painel/Sorteio/Participantes.aspx");
        RouteTable.Routes.MapPageRoute("SorteioResultado",          "Painel/Sorteio/Resultado/{Param}", "~/Painel/Sorteio/Resultado.aspx");

        /* Area do Painel - Informativo */
        RouteTable.Routes.MapPageRoute("Informativo",                   "Painel/Informativo/Informativo", "~/Painel/Informativo/Informativo.aspx");
        RouteTable.Routes.MapPageRoute("InformativoEdita",              "Painel/Informativo/InformativoEdita/{Param}", "~/Painel/Informativo/InformativoEdita.aspx");
    }



    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (HttpContext.Current.User != null)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.User.Identity is FormsIdentity)
                {
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = id.Ticket;

                    var roles = new string[] { ticket.UserData };
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(User.Identity, roles);
                }
            }
        }
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>

