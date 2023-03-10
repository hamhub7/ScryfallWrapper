using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallWrapper.Objects
{
    public class CardSymbol
    {
        /// <summary>
        /// The plaintext symbol. Often surrounded with curly braces {}. Note that not all symbols are ASCII text (for example, {∞}).
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// An alternate version of this symbol, if it is possible to write it without curly braces.
        /// </summary>
        public string? Loose_Variant { get; set; }

        /// <summary>
        /// An English snippet that describes this symbol. Appropriate for use in alt text or other accessible communication formats.
        /// </summary>
        public string English { get; set; }

        /// <summary>
        /// True if it is possible to write this symbol “backwards”. For example, the official symbol {U/P} is sometimes written as {P/U} or {P\U} in informal settings. Note that the Scryfall API never writes symbols backwards in other responses. This field is provided for informational purposes.
        /// </summary>
        public bool Transposable { get; set; }

        /// <summary>
        /// True if this is a mana symbol.
        /// </summary>
        public bool Represents_Mana { get; set; }

        /// <summary>
        /// A decimal number representing this symbol’s converted mana cost. Note that mana symbols from funny sets can have fractional converted mana costs.
        /// </summary>
        public float? Cmc { get; set; }

        /// <summary>
        /// True if this symbol appears in a mana cost on any Magic card. For example {20} has this field set to false because {20} only appears in Oracle text, not mana costs.
        /// </summary>
        public bool Appears_In_Mana_Costs { get; set; }

        /// <summary>
        /// True if this symbol is only used on funny cards or Un-cards.
        /// </summary>
        public bool Funny { get; set; }

        /// <summary>
        /// An array of colors that this symbol represents.
        /// </summary>
        public string[] Colors { get; set; }

        /// <summary>
        /// An array of plaintext versions of this symbol that Gatherer uses on old cards to describe original printed text. For example: {W} has ["oW", "ooW"] as alternates.
        /// </summary>
        public string? Gatherer_Alternative { get; set; }

        /// <summary>
        /// A URI to an SVG image of this symbol on Scryfall’s CDNs.
        /// </summary>
        public string? Svg_Uri { get; set; }
    }

    public class ManaCost
    {
        /// <summary>
        /// The normalized cost, with correctly-ordered and wrapped mana symbols.
        /// </summary>
        public string Cost { get; set; }

        /// <summary>
        /// The converted mana cost. If you submit Un-set mana symbols, this decimal could include fractional parts.
        /// </summary>
        public float Cmc { get; set; }

        /// <summary>
        /// The colors of the given cost.
        /// </summary>
        public string[] Colors { get; set; }

        /// <summary>
        /// True if the cost is colorless.
        /// </summary>
        public bool Colorless { get; set; }

        /// <summary>
        /// True if the cost is monocolored.
        /// </summary>
        public bool Monocolored { get; set; }

        /// <summary>
        /// True if the cost is multicolored.
        /// </summary>
        public bool Multicolored { get; set; }
    }
}
