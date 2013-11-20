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
/// This control will display the related artists
/// </summary>
public partial class RelatedArtistsControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int artistId = GetQueryString();

        //Fetch the realated artists based on an artist ID found in the query string
        ArtistCollection ac = new ArtistCollection(false);
        ac.FetchRelatedArtists(artistId);

        relatedArtistsRepeater.DataSource = ac;
        relatedArtistsRepeater.DataBind();
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
        int artworkId = 0;
        bool flag = Int32.TryParse(Request["id"], out artworkId);

        return artworkId;
    }
}