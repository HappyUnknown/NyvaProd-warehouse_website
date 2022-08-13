﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarouselTest.aspx.cs" Inherits="NyvaProdBC.CarouselTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <meta name="viewport" content="width=device-width" />
        <title>Index</title>
    </head>
    <body>
        <div class="container">
            <div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="2000" data-pause="hover">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                </ol>
                <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <div class="carousel-content">
                            <div style="margin: 0 auto">
                                <h3>#1</h3>
                                <p>
                                    <img alt="The 1st Message." src="http://static.flickr.com/66/199481236_dc98b5abb3_s.jpg"
                                        style="width: 848px; height: 150px" />
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="carousel-content">
                            <div style="margin: 0 auto">
                                <h3>#2</h3>
                                <p>
                                    <img alt="The 2nd Message." src="http://static.flickr.com/75/199481072_b4a0d09597_s.jpg"
                                        style="width: 848px; height: 150px" />
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" />
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        <style type="text/css">
            .carousel-inner {
                width: auto;
                height: 200px;
                max-height: 200px !important;
            }

            .carousel-content {
                color: black;
                display: flex;
                text-align: center;
            }
        </style>
        <script type="text/javascript">
            $(document).ready(function () {
                $('.carousel').carousel();
            });
        </script>
    </body>
    </html>
</asp:Content>
