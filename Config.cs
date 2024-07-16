namespace OclcApiTest
{
    public static class Config
    {
        public static string OclcClientId = "Enter your client ID here";
        public static string OclcClientSecret = "Enter your client secret here";

        public static string OclcTokenUrl = "https://oauth.oclc.org/token";
        public static string OclcScope = "WorldCatMetadataAPI:view_brief_bib WorldCatMetadataAPI:manage_bibs WorldCatMetadataAPI:view_retained_holdings WorldCatMetadataAPI:view_summary_holdings WorldCatMetadataAPI:view_my_holdings WorldCatMetadataAPI:manage_institution_holdings WorldCatMetadataAPI:view_my_local_bib_data WorldCatMetadataAPI:manage_institution_lbds";
        public static string OclcSvcUrl = "https://metadata.api.oclc.org/";

        public static string Publication = @"<marc:collection xmlns:marc=""http://www.loc.gov/MARC21/slim"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.loc.gov/MARC21/slim http://www.loc.gov/standards/marcxml/schema/MARC21slim.xsd"">
<marc:record>
<marc:leader> nam a22 1I 4500</marc:leader>
<marc:controlfield tag=""006"">m</marc:controlfield>
<marc:controlfield tag=""008""> o </marc:controlfield>
<marc:datafield tag=""024"" ind1=""7"" ind2="" "">
<marc:subfield code=""a"">2283525</marc:subfield>
<marc:subfield code=""2"">OSTI ID</marc:subfield>
</marc:datafield>
<marc:datafield tag=""035"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">1a496bc4-12c7-439a-9a93-3889b87962c8</marc:subfield>
</marc:datafield>
<marc:datafield tag=""088"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">NREL/FS-6A40-87298</marc:subfield>
</marc:datafield>
<marc:datafield tag=""245"" ind1=""0"" ind2=""0"">
<marc:subfield code=""a"">Explained: Maintaining a Reliable Future Grid with More Wind and Solar</marc:subfield>
</marc:datafield>
<marc:datafield tag=""260"" ind1="" "" ind2="" "">
<marc:subfield code=""b"">National Renewable Energy Laboratory</marc:subfield>
<marc:subfield code=""c"">2024</marc:subfield>
</marc:datafield>
<marc:datafield tag=""300"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">5 pp.</marc:subfield>
</marc:datafield>
<marc:datafield tag=""500"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">January 2024</marc:subfield>
</marc:datafield>
<marc:datafield tag=""506"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">Publicly released</marc:subfield>
</marc:datafield>
<marc:datafield tag=""513"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">factsheet</marc:subfield>
</marc:datafield>
<marc:datafield tag=""520"" ind1=""3"" ind2="" "">
<marc:subfield code=""a"">Since the early 2000s, maintaining grid reliability has become more complex due to a variety of factors, including the changing generation mix, the creation of wholesale energy markets, and a growing number of extreme weather events. Parts of the U.S. grid are already operating with significant amounts of wind and solar generation - with 2022 annual wind and solar generation in the range of 25% to 40%. Even without considering the effects of extreme weather, maintaining reliability will require new capacity to address both growth in electric demand and retiring capacity. Based on the 2022 North American Electric Reliability Corporation (NERC) Long-Term Reliability Assessment, the combination of both growth in peak demand and retirements suggests a need for more than 100 gigawatts (GW) of new capacity by 2032. In general, there are a five categories of resources that are expected to be deployed and used to meet the challenge of maintaining an adequate source of supply in the coming decades: new wind and solar resources (accounting for their reliability contributions), energy storage, demand response resources, expanded transmission, and continued use of thermal generators.</marc:subfield>
</marc:datafield>
<marc:datafield tag=""591"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">PubHub Collection</marc:subfield>
</marc:datafield>
<marc:datafield tag=""653"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">power grid</marc:subfield>
</marc:datafield>
<marc:datafield tag=""653"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">reliability</marc:subfield>
</marc:datafield>
<marc:datafield tag=""653"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">renewable energy</marc:subfield>
</marc:datafield>
<marc:datafield tag=""653"" ind1="" "" ind2="" "">
<marc:subfield code=""a"">resource adequacy</marc:subfield>
</marc:datafield>
<marc:datafield tag=""856"" ind1=""4"" ind2=""0"">
<marc:subfield code=""u"">https://www.nrel.gov/docs/fy24osti/87298.pdf</marc:subfield>
<marc:subfield code=""y"">PDF</marc:subfield>
</marc:datafield>
</marc:record>
</marc:collection>";
    }
}