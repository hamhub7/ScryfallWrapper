using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallWrapper.Objects
{
    public class CardMigration
    {
        /// <summary>
        /// A link to the current object on Scryfall’s API.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// This migration’s unique UUID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The date this migration was performed.
        /// </summary>
        public string CreatedAt { get; set; }

        /// <summary>
        /// A computer-readable indicator of the migration strategy. See above.
        /// </summary>
        public string MigrationStrategy { get; set; }

        /// <summary>
        /// The id of the affected API Card object.
        /// </summary>
        public string OldScryfallId { get; set; }

        /// <summary>
        /// The replacement id of the API Card object if this is a merge.
        /// </summary>
        public string? NewScryfallId { get; set; }

        /// <summary>
        /// A note left by the Scryfall team about this migration.
        /// </summary>
        public string? Note { get; set; }
    }
}
