<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PID_3_Termo.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    <link href="Javascript/slideshowJquery/bjqs.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.7.1.min.js"></script>    
    <script src="Javascript/slideshowJquery/js/bjqs-1.3.min.js"></script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <section class="destaque">
       <div id="container">
      <div id="banner-fade">
        <!-- start Basic Jquery Slider -->
        <ul class="bjqs">
          <li><img src="Javascript/slideshowJquery/img/banner01.jpg" alt="Alternate Text" /></li>
          <li><img src="Javascript/slideshowJquery/img/banner02.jpg" alt="Alternate Text" /></li>
          <li><img src="Javascript/slideshowJquery/img/banner03.jpg" alt="Alternate Text" /></li>
        </ul>
        <!-- end Basic jQuery Slider -->

      </div>
      <!-- End outer wrapper -->
      <script class="secret-source">
          jQuery(document).ready(function ($) {

              $('#banner-fade').bjqs({
                  height: 330,
                  width: 500,
                  animspeed: 2000,
                  randomstart: true,
                  responsive: true,
                  showcontrols: false
              });

          });
      </script>          
  </div>
    <script src="js/libs/jquery.secret-source.min.js"></script>
    <script>
        jQuery(function ($) {

            $('.secret-source').secretSource({
                includeTag: false
            });

        });
    </script>

  </section>
    <!---  Cima é Slide Show ==== baixo Pesquisa-->
  <section class="destaque busca">

      <div class="tituloPesquisa">
          <span class="">A WESTRAVEL AJUDA VOCÊ A ENCONTRAR SUA VIAGEM</span>
      </div>
      <div class="tipoPesquisa">
          Destino
      </div>
      <div class="pesquisa">
          <asp:TextBox ID="tbPesquisa" runat="server" placeholder="DIGITE O NOME DO DESTINO"></asp:TextBox>
      </div>
  </section>


</asp:Content>


