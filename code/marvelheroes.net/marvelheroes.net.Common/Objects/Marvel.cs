using System;
using System.Collections.Generic;

namespace marvelheroes.net.Common.Objects
{
    public class Marvel
    {
        public int Id { get; set; }
        public DateTime? Modified { get; set; }
        public MarvelImage Thumbnail { get; set; }
        public List<MarvelUrl> Urls { get; set; }
        public string ResourceUri { get; set; }
    }
    public class MarvelUrl
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class MarvelImage
    {
        public string Path { get; set; }
        public string Extension { get; set; }

        public string ImageSource()
        {
            return $"{Path}.{Extension}";
        }
    }

    public class Series : Marvel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Rating { get; set; }
        public MarvelList<MarvelSummary> Comics { get; set; }
        public MarvelList<StorySummary> Stories { get; set; }
        public MarvelList<MarvelSummary> Events { get; set; }
        public MarvelList<CharacterSummary> Characters { get; set; }
        public MarvelList<CreatorSummary> Creators { get; set; }
        public MarvelSummary Next { get; set; }
        public MarvelSummary Previous { get; set; }
    }

    public class Character : Marvel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public MarvelList<MarvelSummary> Comics { get; set; }
        public MarvelList<StorySummary> Stories { get; set; }
        public MarvelList<MarvelSummary> Events { get; set; }
        public MarvelList<MarvelSummary> Series { get; set; }
    }

    public class Comic : Marvel
    {
        public int DigitalId { get; set; }
        public string Title { get; set; }
        public int IssueNumber { get; set; }
        public string VariantDescription { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public string Upc { get; set; }
        public string DiamondCode { get; set; }
        public string Ean { get; set; }
        public string Issn { get; set; }
        public string Format { get; set; }
        public int PageCount { get; set; }
        public List<TextObject> TextObjects { get; set; }
        public MarvelSummary Series { get; set; }
        public List<MarvelSummary> Variants { get; set; }
        public List<MarvelSummary> Collections { get; set; }
        public List<MarvelSummary> CollectedIssues { get; set; }
        public List<ComicDate> Dates { get; set; }
        public List<ComicPrice> Prices { get; set; }
        public List<MarvelImage> Images { get; set; }
        public MarvelList<CreatorSummary> Creators { get; set; }
        public MarvelList<CharacterSummary> Characters { get; set; }
        public MarvelList<StorySummary> Stories { get; set; }
        public MarvelList<MarvelSummary> Events { get; set; }
    }

    public class ComicDate
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class ComicPrice
    {
        public string Type { get; set; }
        public float Price { get; set; }
    }

    public class Creator : Marvel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string FullName { get; set; }
        public MarvelList<MarvelSummary> Series { get; set; }
        public MarvelList<StorySummary> Stories { get; set; }
        public MarvelList<MarvelSummary> Comics { get; set; }
        public MarvelList<MarvelSummary> Events { get; set; }
    }

    public class Event : Marvel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public MarvelList<MarvelSummary> Comics { get; set; }
        public MarvelList<StorySummary> Stories { get; set; }
        public MarvelList<MarvelSummary> Series { get; set; }
        public MarvelList<CharacterSummary> Characters { get; set; }
        public MarvelList<CreatorSummary> Creators { get; set; }
        public MarvelSummary Next { get; set; }
        public MarvelSummary Previous { get; set; }
    }

    public class Story : Marvel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public MarvelList<MarvelSummary> Comics { get; set; }
        public MarvelList<MarvelSummary> SeriesList { get; set; }
        public MarvelList<MarvelSummary> Events { get; set; }
        public MarvelList<CharacterSummary> Characters { get; set; }
        public MarvelList<CreatorSummary> Creators { get; set; }
        public MarvelSummary OriginalIssue { get; set; }
    }


    public class MarvelData<T> where T : Marvel
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }

    public class MarvelRoot<T> where T : Marvel
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHtml { get; set; }
        public string Etag { get; set; }
        public MarvelData<T> Data { get; set; }
    }

    public class TextObject
    {
        public string Type { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
    }

    public class MarvelSummary
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }

    public class CharacterSummary : MarvelSummary
    {
        public string Role { get; set; }
    }

    public class CreatorSummary : MarvelSummary
    {
        public string Role { get; set; }
    }

    public class StorySummary : MarvelSummary
    {
        public string Type { get; set; }
    }


    public class MarvelList<T> where T : MarvelSummary
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionUri { get; set; }
        public List<T> Items { get; set; }
    }
}
