// -----------------------------------------------------------------------
// Interface for parsing routine
// To allow for easy implementation of different HL7 versions
// or parsing of other formats, such as XML.
// -----------------------------------------------------------------------

interface IParser
{

    void parseMSG(string msg);

}
