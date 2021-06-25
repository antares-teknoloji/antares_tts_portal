<%@ control language="C#" autoeventwireup="true" inherits="UserControl_ucMenu, App_Web_jbj1ous3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<style>
    .accordion,
    .accordion ul,
    .accordion li,
    .accordion a,
    .accordion span {
        margin: 0;
        padding: -0;
        border: none;
        outline: none;
    }

        .accordion li {
            list-style: none;
        }

            .accordion li > a {
                display: block;
                position: relative;
                min-width: 110px;
                padding: 0 10px 0 40px;
                color: #fdfdfd;
                font: bold 12px/32px Arial, sans-serif;
                text-decoration: none;
                text-shadow: 0px 1px 0px rgba(0,0,0, .35);
                background: #191C23;
                background: -moz-linear-gradient(top, #6c6e74 0%, #4b4d51 100%);
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#6c6e74), color-stop(100%,#4b4d51));
                background: -webkit-linear-gradient(top, #6c6e74 0%,#4b4d51 100%);
                background: -o-linear-gradient(top, #6c6e74 0%,#4b4d51 100%);
                background: -ms-linear-gradient(top, #6c6e74 0%,#4b4d51 100%);
                background: #6c6e74;
                -webkit-box-shadow: inset 0px 1px 0px 0px rgba(255,255,255, .1), 0px 1px 0px 0px rgba(0,0,0, .1);
                -moz-box-shadow: inset 0px 1px 0px 0px rgba(255,255,255, .1), 0px 1px 0px 0px rgba(0,0,0, .1);
                box-shadow: inset 0px 1px 0px 0px rgba(255,255,255, .1), 0px 1px 0px 0px rgba(0,0,0, .1);
                top: 0px;
                left: -1px;
                height: 35px;
                width: 161px;
                text-align: left;
            }

                .accordion li > a span {
                    display: block;
                    position: absolute;
                    top: 7px;
                    right: 0;
                    padding: 0 10px;
                    margin-right: 10px;
                    font: normal bold 12px/18px Arial, sans-serif;
                    background: #404247;
                    -webkit-border-radius: 15px;
                    -moz-border-radius: 15px;
                    border-radius: 15px;
                    -webkit-box-shadow: inset 1px 1px 1px rgba(0,0,0, .2), 1px 1px 1px rgba(255,255,255, .1);
                    -moz-box-shadow: inset 1px 1px 1px rgba(0,0,0, .2), 1px 1px 1px rgba(255,255,255, .1);
                    box-shadow: inset 1px 1px 1px rgba(0,0,0, .2), 1px 1px 1px rgba(255,255,255, .1);
                }

        .accordion > li > a:before {
            position: absolute;
            top: 0;
            left: 0;
            content: '';
            width: 24px;
            height: 24px;
            margin: 8px 8px;
            background-repeat: no-repeat;
            background-image: url(../img/icons.png);
            background-position: 0px 0px;
        }

        .accordion li.files > a:before {
            background-position: 0px 0px;
        }

        .accordion li.files:hover > a:before,
        .accordion li.files:target > a:before {
            background-position: 0px -24px;
        }

        .accordion li.mail > a:before {
            background-position: -24px 0px;
        }

        .accordion li.mail:hover > a:before,
        .accordion li.mail:target > a:before {
            background-position: -24px -24px;
        }

        .accordion li.cloud > a:before {
            background-position: -48px 0px;
        }

        .accordion li.cloud:hover > a:before,
        .accordion li.cloud:target > a:before {
            background-position: -48px -24px;
        }

        .accordion li.sign > a:before {
            background-position: -72px 0px;
        }

        .accordion li.sign:hover > a:before,
        .accordion li.sign:target > a:before {
            background-position: -72px -24px;
        }

    .sub-menu li a {
        color: #797979;
        text-shadow: 1px 1px 0px rgba(255,255,255, .2);
        background: #e5e5e5;
        border-bottom: 1px solid #c9c9c9;
        -webkit-box-shadow: inset 0px 1px 0px 0px rgba(255,255,255, .1), 0px 1px 0px 0px rgba(0,0,0, .1);
        -moz-box-shadow: inset 0px 1px 0px 0px rgba(255,255,255, .1), 0px 1px 0px 0px rgba(0,0,0, .1);
        box-shadow: inset 0px 1px 0px 0px rgba(255,255,255, .1), 0px 1px 0px 0px rgba(0,0,0, .1);
    }

    .sub-menu li:last-child a {
        border: none;
    }

    .sub-menu li > a span {
        color: #797979;
        text-shadow: 1px 1px 0px rgba(255,255,255, .2);
        background: transparent;
        border: 1px solid #c9c9c9;
        -webkit-box-shadow: none;
        -moz-box-shadow: none;
        box-shadow: none;
    }

    .sub-menu em {
        position: absolute;
        top: 0;
        left: 0;
        margin-left: 14px;
        color: #a6a6a6;
        font: normal 10px/32px Arial, sans-serif;
    }

    .accordion > li:hover > a,
    .accordion > li:target > a {
        color: #3e5706;
        text-shadow: 1px 1px 1px rgba(255,255,255, .2);
        /*background: url(../img/active.png) repeat-x;*/
        background: #a5cd4e;
        background: -moz-linear-gradient(top, #a5cd4e 0%, #6b8f1a 100%);
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#a5cd4e), color-stop(100%,#6b8f1a));
        background: -webkit-linear-gradient(top, #a5cd4e 0%,#6b8f1a 100%);
        background: -o-linear-gradient(top, #a5cd4e 0%,#6b8f1a 100%);
        background: -ms-linear-gradient(top, #a5cd4e 0%,#6b8f1a 100%);
        background: linear-gradient(top, #a5cd4e 0%,#6b8f1a 100%);
    }

        .accordion > li:hover > a span,
        .accordion > li:target > a span {
            color: #fdfdfd;
            text-shadow: 0px 1px 0px rgba(0,0,0, .35);
            background: #3e5706;
        }

    .sub-menu li:hover a {
        background: #efefef;
    }

    .accordion li > .sub-menu {
        height: 0;
        overflow: hidden;
        -webkit-transition: all .2s ease-in-out;
        -moz-transition: all .2s ease-in-out;
        -o-transition: all .2s ease-in-out;
        -ms-transition: all .2s ease-in-out;
        transition: all .2s ease-in-out;
    }

    .accordion li:target > .sub-menu {
        height: 98px;
    }

    .auto-style2 {
        text-align: left;
        margin-left: 0px;
    }
</style>

<div >

    <ul class="accordion">

        <li id="one" class="files">                       
            <a href="#one" <span>          
            <img alt="" src="../img/icons/Credit_Card.png" style="margin-left: 0px" /></span>  Cari Hesaplar </a>

            <ul class="sub-menu">

                <li><a href="#one"><em>01</em>Dropbox<span>42</span></a></li>

                <li><a href="#one"><em>02</em>Skydrive<span>87</span></a></li>

                <li><a href="#one"><em>03</em>FTP Server<span>366</span></a></li>

            </ul>

        </li>

        <li id="two" class="mail">

            <a href="#two">Mail<span>26</span></a>

            <ul class="sub-menu">

                <li><a href="#two"><em>01</em>Hotmail<span>9</span></a></li>

                <li><a href="#two"><em>02</em>Yahoo<span>14</span></a></li>

                <li><a href="#two"><em>03</em>Gmail<span>3</span></a></li>

            </ul>

        </li>

        <li id="three" class="cloud">

            <a href="#three">Cloud<span>58</span></a>

            <ul class="sub-menu">

                <li><a href="#three"><em>01</em>Connect<span>12</span></a></li>

                <li><a href="#three"><em>02</em>Profiles<span>19</span></a></li>

                <li><a href="#three"><em>03</em>Options<span>27</span></a></li>

            </ul>

        </li>

        <li id="four" class="sign">

            <a href="#four">Sign Out</a>

            <ul class="sub-menu">

                <li><a href="#four"><em>01</em>Log Out</a></li>

                <li><a href="#four"><em>02</em>Delete Account</a></li>

                <li><a href="#four"><em>03</em>Freeze Account</a></li>

            </ul>

        </li>

    </ul>

</div>

<div id="wrapper-200b">

    <ul class="accordion">

        <li id="one2" class="files">

            <a href="#one2">My Files<span>495</span></a>

            <ul class="sub-menu">

                <li><a href="#one2"><em>01</em>Dropbox<span>42</span></a></li>

                <li><a href="#one2"><em>02</em>Skydrive<span>87</span></a></li>

                <li><a href="#one2"><em>03</em>FTP Server<span>366</span></a></li>

            </ul>

        </li>

        <li id="two2" class="mail">

            <a href="#two2">Mail<span>26</span></a>

            <ul class="sub-menu">

                <li><a href="#two2"><em>01</em>Hotmail<span>9</span></a></li>

                <li><a href="#two2"><em>02</em>Yahoo<span>14</span></a></li>

                <li><a href="#two2"><em>03</em>Gmail<span>3</span></a></li>

            </ul>

        </li>

        <li id="three2" class="cloud">

            <a href="#three2">Cloud<span>58</span></a>

            <ul class="sub-menu">

                <li><a href="#three2"><em>01</em>Connect<span>12</span></a></li>

                <li><a href="#three2"><em>02</em>Profiles<span>19</span></a></li>

                <li><a href="#three2"><em>03</em>Options<span>27</span></a></li>

            </ul>

        </li>

        <li id="four2" class="sign">

            <a href="#four2">Sign Out</a>

            <ul class="sub-menu">

                <li><a href="#four2"><em>01</em>Log Out</a></li>

                <li><a href="#four2"><em>02</em>Delete Account</a></li>

                <li><a href="#four2"><em>03</em>Freeze Account</a></li>

            </ul>

        </li>

    </ul>

</div>

<div id="wrapper-600">

    <ul class="accordion">

        <li id="one3" class="files">

            <a href="#one3">My Files<span>495</span></a>

            <ul class="sub-menu">

                <li><a href="#one3"><em>01</em>Dropbox<span>42</span></a></li>

                <li><a href="#one3"><em>02</em>Skydrive<span>87</span></a></li>

                <li><a href="#one3"><em>03</em>FTP Server<span>366</span></a></li>

            </ul>

        </li>

        <li id="two3" class="mail">

            <a href="#two3">Mail<span>26</span></a>

            <ul class="sub-menu">

                <li><a href="#two3"><em>01</em>Hotmail<span>9</span></a></li>

                <li><a href="#two3"><em>02</em>Yahoo<span>14</span></a></li>

                <li><a href="#two3"><em>03</em>Gmail<span>3</span></a></li>

            </ul>

        </li>

        <li id="three3" class="cloud">

            <a href="#three3">Cloud<span>58</span></a>

            <ul class="sub-menu">

                <li><a href="#three3"><em>01</em>Connect<span>12</span></a></li>

                <li><a href="#three3"><em>02</em>Profiles<span>19</span></a></li>

                <li><a href="#three3"><em>03</em>Options<span>27</span></a></li>

            </ul>

        </li>

        <li id="four3" class="sign">

            <a href="#four3">Sign Out</a>

            <ul class="sub-menu">

                <li><a href="#four3"><em>01</em>Log Out</a></li>

                <li><a href="#four3"><em>02</em>Delete Account</a></li>

                <li><a href="#four3"><em>03</em>Freeze Account</a></li>

            </ul>

        </li>

    </ul>

</div>


