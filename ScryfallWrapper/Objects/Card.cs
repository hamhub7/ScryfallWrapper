using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallWrapper.Objects
{
    public class Card
    {
        // Core Fields

        /// <summary>
        /// This card’s Arena ID, if any. A large percentage of cards are not available on Arena and do not have this ID.
        /// </summary>
        public int? ArenaId { get; set; }

        /// <summary>
        /// A unique ID for this card in Scryfall’s database.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A language code for this printing.
        /// </summary>
        public string Lang { get; set; }

        /// <summary>
        /// This card’s Magic Online ID (also known as the Catalog ID), if any. A large percentage of cards are not available on Magic Online and do not have this ID.
        /// </summary>
        public int? MtgoId { get; set; }

        /// <summary>
        /// This card’s foil Magic Online ID (also known as the Catalog ID), if any. A large percentage of cards are not available on Magic Online and do not have this ID.
        /// </summary>
        public int? MtgoFoilId { get; set; }

        /// <summary>
        /// This card’s multiverse IDs on Gatherer, if any, as an array of integers. Note that Scryfall includes many promo cards, tokens, and other esoteric objects that do not have these identifiers.
        /// </summary>
        public int[]? MultiverseIds { get; set; }

        /// <summary>
        /// This card’s ID on TCGplayer’s API, also known as the productId.
        /// </summary>
        public int? TcgplayerId { get; set; }

        /// <summary>
        /// This card’s ID on TCGplayer’s API, for its etched version if that version is a separate product.
        /// </summary>
        public int? TcgplayerEtchedId { get; set; }

        /// <summary>
        /// This card’s ID on Cardmarket’s API, also known as the idProduct.
        /// </summary>
        public int? CardmarketId { get; set; }

        /// <summary>
        /// A unique ID for this card’s oracle identity. This value is consistent across reprinted card editions, and unique among different cards with the same name (tokens, Unstable variants, etc).
        /// </summary>
        public string OracleId { get; set; }

        /// <summary>
        /// A link to where you can begin paginating all re/prints for this card on Scryfall’s API.
        /// </summary>
        public string PrintsSearchUri { get; set; }

        /// <summary>
        /// A link to this card’s rulings list on Scryfall’s API.
        /// </summary>
        public string RulingsUri { get; set; }

        /// <summary>
        /// A link to this card’s permapage on Scryfall’s website.
        /// </summary>
        public string ScryfallUri { get; set; }

        /// <summary>
        /// A link to this card object on Scryfall’s API.
        /// </summary>
        public string Uri { get; set; }


        // Gameplay Fields

        /// <summary>
        /// If this card is closely related to other cards, this property will be an array with Related Card Objects.
        /// </summary>
        public RelatedCard[]? AllParts { get; set; }

        /// <summary>
        /// An array of Card Face objects, if this card is multifaced.
        /// </summary>
        public CardFace[]? CardFaces { get; set; }

        /// <summary>
        /// The card’s converted mana cost. Note that some funny cards have fractional mana costs.
        /// </summary>
        public float Cmc { get; set; }

        /// <summary>
        /// This card’s colors, if the overall card has colors defined by the rules. Otherwise the colors will be on the card_faces objects, see below.
        /// </summary>
        public string[]? Colors { get; set; }

        /// <summary>
        /// This card’s overall rank/popularity on EDHREC. Not all cards are ranked.
        /// </summary>
        public int? EdhrecRank { get; set; }

        /// <summary>
        /// This card’s hand modifier, if it is Vanguard card. This value will contain a delta, such as -1.
        /// </summary>
        public string? HandModifier { get; set; }

        /// <summary>
        /// An array of keywords that this card uses, such as 'Flying' and 'Cumulative upkeep'.
        /// </summary>
        public string[] Keywords { get; set; }

        /// <summary>
        /// A code for this card’s layout.
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// An object describing the legality of this card across play formats. Possible legalities are legal, not_legal, restricted, and banned.
        /// </summary>
        public object Legalities { get; set; }

        /// <summary>
        /// This card’s life modifier, if it is Vanguard card. This value will contain a delta, such as +2.
        /// </summary>
        public string? LifeModifier { get; set; }

        /// <summary>
        /// This loyalty if any. Note that some cards have loyalties that are not numeric, such as X.
        /// </summary>
        public string? Loyalty { get; set; }

        /// <summary>
        /// The mana cost for this card. This value will be any empty string "" if the cost is absent. Remember that per the game rules, a missing mana cost and a mana cost of {0} are different values. Multi-faced cards will report this value in card faces.
        /// </summary>
        public string? ManaCost { get; set; }

        /// <summary>
        /// The name of this card. If this card has multiple faces, this field will contain both names separated by ␣//␣.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Oracle text for this card, if any.
        /// </summary>
        public string? OracleText { get; set; }

        /// <summary>
        /// True if this card is oversized.
        /// </summary>
        public bool Oversized { get; set; }

        /// <summary>
        /// This card’s rank/popularity on Penny Dreadful. Not all cards are ranked.
        /// </summary>
        public int? PennyRank { get; set; }

        /// <summary>
        /// This card’s power, if any. Note that some cards have powers that are not numeric, such as *.
        /// </summary>
        public string? Power { get; set; }

        /// <summary>
        /// Colors of mana that this card could produce.
        /// </summary>
        public string[]? ProducedMana { get; set; }

        /// <summary>
        /// True if this card is on the Reserved List.
        /// </summary>
        public bool Reserved { get; set; }

        /// <summary>
        /// This card’s toughness, if any. Note that some cards have toughnesses that are not numeric, such as *.
        /// </summary>
        public string? Toughness { get; set; }

        /// <summary>
        /// The type line of this card.
        /// </summary>
        public string TypeLine { get; set; }


        // Print Fields

        /// <summary>
        /// The name of the illustrator of this card. Newly spoiled cards may not have this field yet.
        /// </summary>
        public string? Artist { get; set; }

        /// <summary>
        /// The lit Unfinity attractions lights on this card, if any.
        /// </summary>
        public int[]? AttractionLights { get; set; }

        /// <summary>
        /// Whether this card is found in boosters.
        /// </summary>
        public bool Booster { get; set; }

        /// <summary>
        /// This card’s border color: black, white, borderless, silver, or gold.
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// The Scryfall ID for the card back design present on this card.
        /// </summary>
        public string CardBackId { get; set; }

        /// <summary>
        /// This card’s collector number. Note that collector numbers can contain non-numeric characters, such as letters or ★.
        /// </summary>
        public string CollectorNumber { get; set; }

        /// <summary>
        /// True if you should consider avoiding use of this print downstream.
        /// </summary>
        public bool? ContentWarning { get; set; }

        /// <summary>
        /// True if this card was only released in a video game.
        /// </summary>
        public bool Digital { get; set; }

        /// <summary>
        /// An array of computer-readable flags that indicate if this card can come in foil, nonfoil, or etched finishes.
        /// </summary>
        public string[] Finishes { get; set; }

        /// <summary>
        /// The just-for-fun name printed on the card (such as for Godzilla series cards).
        /// </summary>
        public string? FlavorName { get; set; }

        /// <summary>
        /// The flavor text, if any.
        /// </summary>
        public string? FlavorText { get; set; }

        /// <summary>
        /// This card’s frame effects, if any.
        /// </summary>
        public string? FrameEffects { get; set; }

        /// <summary>
        /// This card's frame layout.
        /// </summary>
        public string Frame { get; set; }

        /// <summary>
        /// True if this card’s artwork is larger than normal.
        /// </summary>
        public bool FullArt { get; set; }

        /// <summary>
        /// A list of games that this card print is available in, paper, arena, and/or mtgo.
        /// </summary>
        public string[] Games { get; set; }

        /// <summary>
        /// True if this card’s imagery is high resolution.
        /// </summary>
        public bool HighresImage { get; set; }

        /// <summary>
        /// A unique identifier for the card artwork that remains consistent across reprints. Newly spoiled cards may not have this field yet.
        /// </summary>
        public string? IllustrationId { get; set; }

        /// <summary>
        /// A computer-readable indicator for the state of this card’s image, one of missing, placeholder, lowres, or highres_scan.
        /// </summary>
        public string ImageStatus { get; set; }

        /// <summary>
        /// An object listing available imagery for this card. See the Card Imagery article for more information.
        /// </summary>
        public object? ImageUris { get; set; }

        /// <summary>
        /// An object containing daily price information for this card, including usd, usd_foil, usd_etched, eur, and tix prices, as strings.
        /// </summary>
        public object Prices { get; set; }

        /// <summary>
        /// The localized name printed on this card, if any.
        /// </summary>
        public string? PrintedName { get; set; }

        /// <summary>
        /// The localized text printed on this card, if any.
        /// </summary>
        public string? PrintedText { get; set; }

        /// <summary>
        /// The localized type line printed on this card, if any.
        /// </summary>
        public string? PrintedTypeLine { get; set; }

        /// <summary>
        /// True if this card is a promotional print.
        /// </summary>
        public bool Promo { get; set; }

        /// <summary>
        /// An array of strings describing what categories of promo cards this card falls into.
        /// </summary>
        public string[]? PromoTypes { get; set; }

        /// <summary>
        /// An object providing URIs to this card’s listing on major marketplaces.
        /// </summary>
        public object PurchaseUris { get; set; }

        /// <summary>
        /// This card’s rarity. One of common, uncommon, rare, special, mythic, or bonus.
        /// </summary>
        public string Rarity { get; set; }

        /// <summary>
        /// An object providing URIs to this card’s listing on other Magic: The Gathering online resources.
        /// </summary>
        public object RelatedUris { get; set; }

        /// <summary>
        /// The date this card was first released.
        /// </summary>
        public string ReleasedAt { get; set; }

        /// <summary>
        /// True if this card is a reprint.
        /// </summary>
        public bool Reprint { get; set; }

        /// <summary>
        /// A link to this card’s set on Scryfall’s website.
        /// </summary>
        public string ScryfallSetUri { get; set; }

        /// <summary>
        /// This card’s full set name.
        /// </summary>
        public string SetName { get; set; }

        /// <summary>
        /// A link to where you can begin paginating this card’s set on the Scryfall API.
        /// </summary>
        public string SetSearchUri { get; set; }

        /// <summary>
        /// The type of set this printing is in.
        /// </summary>
        public string SetType { get; set; }

        /// <summary>
        /// A link to this card’s set object on Scryfall’s API.
        /// </summary>
        public string SetUri { get; set; }

        /// <summary>
        /// This card's set code.
        /// </summary>
        public string Set { get; set; }

        /// <summary>
        /// This card’s Set object UUID.
        /// </summary>
        public string SetId { get; set; }

        /// <summary>
        /// True if this card is a Story Spotlight.
        /// </summary>
        public bool StorySpotlight { get; set; }

        /// <summary>
        /// True if the card is printed without text.
        /// </summary>
        public bool Textless { get; set; }

        /// <summary>
        /// Whether this card is a variation of another printing.
        /// </summary>
        public bool Variation { get; set; }

        /// <summary>
        /// The printing ID of the printing this card is a variation of.
        /// </summary>
        public string? VariationOf { get; set; }

        /// <summary>
        /// The security stamp on this card, if any. One of oval, triangle, acorn, circle, arena, or heart.
        /// </summary>
        public string? SecurityStamp { get; set; }

        /// <summary>
        /// This card’s watermark, if any.
        /// </summary>
        public string? Watermark { get; set; }
    }

    public class CardFace
    {
        /// <summary>
        /// The name of the illustrator of this card face. Newly spoiled cards may not have this field yet.
        /// </summary>
        public string? Artist { get; set; }

        /// <summary>
        /// The mana value of this particular face, if the card is reversible.
        /// </summary>
        public float? Cmc { get; set; }

        /// <summary>
        /// The colors in this face’s color indicator, if any.
        /// </summary>
        public string[]? ColorIndicator { get; set; }

        /// <summary>
        /// This face’s colors, if the game defines colors for the individual face of this card.
        /// </summary>
        public string[]? Colors { get; set; }

        /// <summary>
        /// The flavor text printed on this face, if any.
        /// </summary>
        public string? FlavorText { get; set; }

        /// <summary>
        /// A unique identifier for the card face artwork that remains consistent across reprints. Newly spoiled cards may not have this field yet.
        /// </summary>
        public string? IllustrationId { get; set; }

        /// <summary>
        /// An object providing URIs to imagery for this face, if this is a double-sided card. If this card is not double-sided, then the image_uris property will be part of the parent object instead.
        /// </summary>
        public object? ImageUris { get; set; }

        /// <summary>
        /// The layout of this card face, if the card is reversible.
        /// </summary>
        public string? Layout { get; set; }

        /// <summary>
        /// This face’s loyalty, if any.
        /// </summary>
        public string? Loyalty { get; set; }

        /// <summary>
        /// The mana cost for this face. This value will be any empty string "" if the cost is absent. Remember that per the game rules, a missing mana cost and a mana cost of {0} are different values.
        /// </summary>
        public string ManaCost { get; set; }

        /// <summary>
        /// The name of this particular face.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Oracle ID of this particular face, if the card is reversible.
        /// </summary>
        public string? OracleId { get; set; }

        /// <summary>
        /// The Oracle text for this face, if any.
        /// </summary>
        public string? OracleText { get; set; }

        /// <summary>
        /// This face’s power, if any. Note that some cards have powers that are not numeric, such as *.
        /// </summary>
        public string? Power { get; set; }

        /// <summary>
        /// The localized name printed on this face, if any.
        /// </summary>
        public string? PrintedName { get; set; }

        /// <summary>
        /// The localized text printed on this face, if any.
        /// </summary>
        public string? PrintedText { get; set; }

        /// <summary>
        /// The localized type line printed on this face, if any.
        /// </summary>
        public string? PrintedTypeLine { get; set; }

        /// <summary>
        /// This face’s toughness, if any.
        /// </summary>
        public string? Toughness { get; set; }

        /// <summary>
        /// The type line of this particular face, if the card is reversible.
        /// </summary>
        public string? TypeLine { get; set; }

        /// <summary>
        /// The watermark on this particular card face, if any.
        /// </summary>
        public string? Watermark { get; set; }
    }

    public class RelatedCard
    {
        /// <summary>
        /// An unique ID for this card in Scryfall’s database.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A field explaining what role this card plays in this relationship, one of token, meld_part, meld_result, or combo_piece.
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// The name of this particular related card
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type line of this card.
        /// </summary>
        public string TypeLine { get; set; }

        /// <summary>
        /// A URI where you can retrieve a full object describing this card on Scryfall’s API.
        /// </summary>
        public string Uri { get; set; }
    }
}
