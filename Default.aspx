<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no, target-densityDpi=device-dpi" />
    <link href="css/bootstrap-responsive.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css"/>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
 

  <style>
img {
  display: block;
  margin-left: auto;
  margin-right: auto;
}

h6{
    display:inline-block;
    
}
 
.align-left{
    float: left;
    color:rgb(90, 90, 90);
}
.align-right{
    float: right;
    color:rgb(90, 90, 90);
}
.responsive{
    max-width:100%;
    height:auto;
}
.btn{
    border-radius: 15px;
    color:black;
}
.btn:link,
.btn:visited {
    text-transform: uppercase;
    text-decoration: none;
    padding: 15px 40px;
    display: inline-block;
    transition: all .2s;
    position: absolute;
     -moz-border-radius: 50%;
    -webkit-border-radius: 50%;
    border-radius: 50%
}

.btn:hover {
    transform: translateY(-3px);
    box-shadow: 0 10px 20px rgba(0, 0, 0, 0.2);
}

.btn:active {
    transform: translateY(-1px);
    box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
}

.btn-white {
    background-color: ;
    color: #777;
}

.btn::after {
    content: "";
    display: inline-block;
    height: 100%;
    width: 100%;
    border-radius: 100px;
    position: absolute;
    top: 0;
    left: 0;
    z-index: -1;
    transition: all .4s;
     -moz-border-radius: 50%;
    -webkit-border-radius: 50%;
    border-radius: 50%
}




.btn:hover::after {
    transform: scaleX(1.4) scaleY(1.6);
    opacity: 0;
}

.btn-animated {
    animation: moveInBottom 5s ease-out;
    animation-fill-mode: backwards;
}

@keyframes moveInBottom {
    0% {
        opacity: 0;
        transform: translateY(30px);
    }

    100% {
        opacity: 1;
        transform: translateY(0px);
    }
}

</style>
     
    <title>Hilmi Beken Müşteri Portalı</title>
</head>
<body>
   <form method="post" id="form1" runat="server" >
       <div class="container">
           <div class="row">
               <div class="col-md-4 col-md-offset-4">
                   <div class="login-panel panel panel-default" style="margin-top:40px;height:480px;">
                       <div class="panel-heading" style="background-color: lightslategray;color: blue">
                           <h3 class="panel-title"></h3>
                       </div>
                            <br/>
                       <img src="image/logo_beken.png" class="responsive"   width="300" height="100"/>
                        <br/>
                        <br/>
                        <br/>
                       <div class="panel-body">
                           <div class="form-group">
                               <label for="emailField">Kullanıcı Adı</label>
                               <div class="input-group">
                                   <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                   <asp:TextBox ID="txtKullaniciAd" runat="server" CssClass="form-control" Height="40px"></asp:TextBox>
                               </div>
                           </div>
                           <div class="form-group">
                               <label for="emailField">Şifre</label>
                               <div class="input-group">
                                   <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                   <asp:TextBox ID="txtParola" runat="server" CssClass="form-control" TextMode="Password" Height="40px"></asp:TextBox>
                               </div>
                           </div>      
                           
                        <br />
                           
                          <div style="width: 500px" >
                           <asp:Button  ID="btnGiris" OnClientClick="btnGiris_Click"  runat="server" CssClass="btn"  Text="Giriş" OnClick="btnGiris_Click" BorderColor="black" Height="40px" Width="150px" />
                           </div>
                                
                              <br />
                               
                           </div>
                          </div>
                            
                       </div>


              
               </div>
       </div>
     </form>
</body>
</html>
