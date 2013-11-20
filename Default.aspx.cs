using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Content.Business;
using Content.DataAccess;
using System.Data;

/// <summary>
/// This will load all of the content in the main page
/// </summary>
public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Load Top 4 artworks based on sales
            ArtWorkCollection awc = new ArtWorkCollection();
            awc.FetchMostSales(4);
            topArtWorkRepeater.DataSource = awc;
            topArtWorkRepeater.DataBind();

            //Load top 4 artists based on sales
            ArtistCollection ac = new ArtistCollection(false);
            ac.FetchMostSales(4);
            topArtistRepeater.DataSource = ac;
            topArtistRepeater.DataBind();

            //Load the first 4 artworks
            ArtWorkCollection newAdditionsAC = new ArtWorkCollection();
            newAdditionsAC.FetchTop(4);
            newAdditionsRepeater.DataSource = newAdditionsAC;
            newAdditionsRepeater.DataBind();
        }
    }

    /// <summary>
    /// This is an event handler for the artwork fav button that will 
    /// add the artwork to the favorites list
    /// </summary>
    protected void AddArtworkFav_OnClick(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);

        //Get ArtWork Info---------------------------
        int id = Convert.ToInt32(btn.CommandArgument);

        FavBtn favBtn = new FavBtn(id);

        favBtn.addArtworkFav();
    }

    /// <summary>
    /// This is an event handler fo the artist fav button that will 
    /// add the artists to the favorites list
    /// </summary>
    protected void AddArtistFav_OnClick(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);

        //Get ArtWork Info---------------------------
        int id = Convert.ToInt32(btn.CommandArgument);

        FavBtn favBtn = new FavBtn(id);

        favBtn.addArtistFav();
    }
}
