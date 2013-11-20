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
/// This will load all the artist information for a single artist
/// </summary>
public partial class SingleArtist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int artistId = GetQueryString();

            //Fetch the artist information based on the artist ID in the query string
            ArtistCollection ac = new ArtistCollection(false);
            ac.FetchForId(artistId);

            artistDetails.DataSource = ac;

            artistDetails.DataBind();
        }
    }

    /// <summary>
    /// This is an event handler for the artist fav button that will 
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

    private int GetQueryString()
    {
        int artistId = 0;
        bool flag = Int32.TryParse(Request["id"], out artistId);

        return artistId;
    }
}