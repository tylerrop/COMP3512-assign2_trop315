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
/// This will show a list of all the artworks
/// </summary>
public partial class ArtworkList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            //auto fill up the collection with all of the artworks
            ArtWorkCollection ac = new ArtWorkCollection();

            ac.FetchAll();

            artworkList.DataSource = ac;

            artworkList.DataBind();
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
}