<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArtistPaintingsControl.ascx.cs" Inherits="ArtistPaintings" %>

<asp:Repeater ID="artDetails" runat="server" >
                    <ItemTemplate>
                        <div class="listThumbNail col-xs-12 col-sm-6 col-md-4 col-lg-3 panelGroupMinHeight">
                            <!--Item template-->
                            <!--ArtWork image-->
                            <a href="SingleArtWork.aspx?id=<%# Eval("Id") %>"">
                                <img src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="<%# Eval("ID") %>" class="thumbnail singlePaintingByArtistIMG" />
                                <p class="centerMarginsPanelPara orange-text overFlow"><%# Eval("Title") %></p>
                            </a>
                    
                            <br />

                        <asp:LinkButton runat="server"  CssClass="btn btn-default blueLinks fullWidth bottom" ID="addFavButton" OnClick="AddArtworkFav_OnClick" CommandArgument=<%# Eval("Id") %> >
                            <span class="glyphicon glyphicon-heart blueLinks"></span> Add to Favorites
                        </asp:LinkButton>
                        <!--End of thumbnail-->
                        </div>
                    </ItemTemplate>
               </asp:Repeater>