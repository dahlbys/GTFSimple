using System;

namespace GTFSimple.Core
{
    /// <summary>
    /// The file contains information about the feed itself, rather than the services that the feed describes. 
    /// GTFS currently has an agency.txt file to provide information about the agencies that operate the services described by the feed. 
    /// However, the publisher of the feed is sometimes a different entity than any of the agencies (in the case of regional aggregators). 
    /// In addition, there are some fields that are really feed-wide settings, rather than agency-wide.
    /// </summary>
    public class FeedInfo
    {
        /// <summary>
        /// Gets or sets the name of the feed publisher. Required.
        /// 
        /// The feed_publisher_name field contains the full name of the organization that publishes the feed. 
        /// (This may be the same as one of the agency_name values in agency.txt.) 
        /// GTFS-consuming applications can display this name when giving attribution for a particular feed's data.
        /// </summary>
        /// <value>The name of the feed publisher.</value>
        public string FeedPublisherName { get; set; }

        /// <summary>
        /// Gets or sets the feed publisher URL. Required.
        /// </summary>
        /// <value>The feed publisher URL.</value>
        /// <remarks>
        /// The feed_publisher_url field contains the URL of the feed publishing organization's website. 
        /// (This may be the same as one of the agency_url values in agency.txt.) 
        /// The value must be a fully qualified URL that includes http:// or https://, 
        /// and any special characters in the URL must be correctly escaped. See http://www.w3.org/Addressing/URL/4_URI_Recommentations.html 
        /// for a description of how to create fully qualified URL values.
        /// </remarks>
        public Uri FeedPublisherUrl { get; set; }

        /// <summary>
        /// Gets or sets the feed language. Required.
        /// 
        /// The feed_lang field contains a IETF BCP 47 language code specifying the default language used for the text in this feed. 
        /// This setting helps GTFS consumers choose capitalization rules and other language-specific settings for the feed. 
        /// For an introduction to IETF BCP 47, please refer to http://www.rfc-editor.org/rfc/bcp/bcp47.txt and http://www.w3.org/International/articles/language-tags/.
        /// </summary>
        /// <value>The feed language.</value>
        public string FeedLanguage { get; set; }

        /// <summary>
        /// Gets or sets the feed start date. Optional.
        /// 
        /// The feed provides complete and reliable schedule information for service in the period from the beginning of the feed_start_date day to the end of the feed_end_date day. 
        /// Both days are given as dates in YYYYDDMM format as for calendar.txt, or left empty if unavailable. 
        /// The feed_end_date date must not precede the feed_start_date date if both are given. 
        /// Feed providers are encouraged to give schedule data outside this period to advise of likely future service, 
        /// but feed consumers should treat it mindful of its non-authoritative status. 
        /// If feed_start_date or feed_end_date extend beyond the active calendar dates defined in calendar.txt and calendar_dates.txt, 
        /// the feed is making an explicit assertion that there is no service for dates within the feed_start_date or feed_end_date range but not included in the active calendar dates.
        /// </summary>
        /// <value>The feed start date.</value>
        public DateTime? FeedStartDate { get; set; }

        /// <summary>
        /// Gets or sets the feed end date. Optional.
        /// 
        /// The feed provides complete and reliable schedule information for service in the period from the beginning of the feed_start_date day to the end of the feed_end_date day. 
        /// Both days are given as dates in YYYYDDMM format as for calendar.txt, or left empty if unavailable. 
        /// The feed_end_date date must not precede the feed_start_date date if both are given. 
        /// Feed providers are encouraged to give schedule data outside this period to advise of likely future service, 
        /// but feed consumers should treat it mindful of its non-authoritative status. 
        /// If feed_start_date or feed_end_date extend beyond the active calendar dates defined in calendar.txt and calendar_dates.txt, 
        /// the feed is making an explicit assertion that there is no service for dates within the feed_start_date or feed_end_date range but not included in the active calendar dates.
        /// </summary>
        /// <value>The feed end date.</value>
        public DateTime? FeedEndDate { get; set; }
        /// <summary>
        /// Gets or sets the feed version. Optional.
        /// 
        /// The feed publisher can specify a string here that indicates the current version of their GTFS feed. 
        /// GTFS-consuming applications can display this value to help feed publishers determine whether the latest version of their feed has been incorporated.
        /// </summary>
        /// <value>The feed version.</value>
        public string FeedVersion { get; set; }

    }
}

