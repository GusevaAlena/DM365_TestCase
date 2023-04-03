namespace DM365News.Database
{
    public static class DbConstants
    {
        public const string NewsFileName = "News.json";
        public const string Url = "https://datamanagement365.com/blog/news/";
        public const string MainSiteUrl = "https://datamanagement365.com";
        public const string PathToDatabase = @"..\DM365News.Database\";

        public const string AllNewsSelector = ".news__default";
        public const string NewsInfoSelector = ".info__default";
        public const string NewsTypeSelector = ".badge";
        public const string ArticleType = "Article";
        public const string NewsReferenceSelector = ".news__default__title a";
        public const string NewsDateSelector = ".date-normal";
        public const string ReferenceAttribute = "href";
        public const string NewsNoticeSelector = ".notice__default";
        public const string NewsImageSelector = "img";
        public const string ImageSrcAttribute = "src";
    }
}
