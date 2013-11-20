<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RelatedArtworksControl.ascx.cs" Inherits="Controls_RelatedArtworksControl" %>

<asp:Repeater ID="relatedArtworkRepeater" runat="server">
    <ItemTemplate>
        <!--EXTRA, cut out once repeater is made-->
                    <div class="listThumbNail col-xs-12 col-sm-6 col-md-4 col-lg-3 panelGroupMinHeight">
                        <a href="SingleArtwork.aspx?id=<%# Eval("Id") %>">
                            <img src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" class="thumbnail singlePaintingByArtistIMG" />
                            <p class="centerMarginsPanelPara overFlow orange-text"><%# Eval("Title") %></p>
                        </a>
                        <br />
                        <asp:LinkButton runat="server"  CssClass="noTopMargin btn btn-default blueLinks relatedArtistFavZeroTop" ID="addFavButton" OnClick="AddArtworkFav_OnClick" CommandArgument=<%# Eval("Id") %> >
                            <span class="glyphicon glyphicon-heart blueLinks"></span> Add to Favorites
                        </asp:LinkButton>
                    </div>
    </ItemTemplate>
</asp:Repeater>