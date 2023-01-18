using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallWrapper.Objects
{
    public class Set
    {
        /// <summary>
        /// A unique ID for this set on Scryfall that will not change.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The unique three to five-letter code for this set.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The unique code for this set on MTGO, which may differ from the regular code.
        /// </summary>
        public string? Mtgo_Code { get; set; }

        /// <summary>
        /// This set’s ID on TCGplayer’s API, also known as the groupId.
        /// </summary>
        public int? Tcgplayer_Id { get; set; }

        /// <summary>
        /// The English name of the set.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A computer-readable classification for this set. See below.
        /// </summary>
        public string Set_Type { get; set; }

        /// <summary>
        /// The date the set was released or the first card was printed in the set (in GMT-8 Pacific time).
        /// </summary>
        public string? Released_At { get; set; }

        /// <summary>
        /// The block code for this set, if any.
        /// </summary>
        public string? Block_Code { get; set; }

        /// <summary>
        /// The block or group name code for this set, if any.
        /// </summary>
        public string? Block { get; set; }

        /// <summary>
        /// The set code for the parent set, if any. promo and token sets often have a parent set.
        /// </summary>
        public string? Parent_Set_Code { get; set; }

        /// <summary>
        /// The number of cards in this set.
        /// </summary>
        public int Card_Count { get; set; }

        /// <summary>
        /// The denominator for the set’s printed collector numbers.
        /// </summary>
        public int? Printed_Size { get; set; }

        /// <summary>
        /// True if this set was only released in a video game.
        /// </summary>
        public bool Digital { get; set; }

        /// <summary>
        /// True if this set contains only foil cards.
        /// </summary>
        public bool Foil_Only { get; set; }

        /// <summary>
        /// True if this set contains only nonfoil cards.
        /// </summary>
        public bool Nonfoil_Only { get; set; }

        /// <summary>
        /// A link to this set’s permapage on Scryfall’s website.
        /// </summary>
        public string Scryfall_Uri { get; set; }

        /// <summary>
        /// 	A link to this set object on Scryfall’s API.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// A URI to an SVG file for this set’s icon on Scryfall’s CDN. Hotlinking this image isn’t recommended, because it may change slightly over time. You should download it and use it locally for your particular user interface needs.
        /// </summary>
        public string Icon_Svg_Uri { get; set; }

        /// <summary>
        /// A Scryfall API URI that you can request to begin paginating over the cards in this set.
        /// </summary>
        public string Search_Uri { get; set; }
    }
}
