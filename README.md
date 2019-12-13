# uipath-utils
RPA utilities created in UiPath

## Adobe
### Acrobat_Print_To_PDF.xaml ###
Print a file to PDF. This was originally used as a hack to unlock a PDF file.

**Arguments**  
    **IN**  
        *vstr_infile_path* - The file path of the input file. Can be absolute or relative.   
    **OUT**   
        *vstr_outfile_path* - The file path of where to save the output file. Can be absolute or relative.

### Acrobat_Convert.xaml
Convert a file to PDF via Aboe Acrobat GUI.

**Arguments**  
    **IN**  
        *vstr_infile_path* - The file path of the input file. Can be absolute or relative.   
    **OUT**   
        *vstr_outfile_path* -  The file path of where to save the output PDF file. Can be absolute or relative.

## NLP
### Semantic_Compare.xaml
Use [Cortical.IO](https://www.cortical.io) to return a semantic comparison of 2 words. A reference to the response parameters can be found [here](https://www.cortical.io/resources_apidocumentation.html) in the "similarity metrics guide". You may need a free API key found on the coritcal [site](https://www.cortical.io).

**Arguments**   
    **IN**   
        *vstr_word_A* - The first string needed to compare.   
        *vstr_word_B*- The string to comapre the first one against.    
    **OUT**   
        * json_comparison - A JSON object containing the comparison results of the input strings.   
**Sample Output:**   
```
// Request
[
    { "text":"Exterior Property Inspection" },
    { "text":"Attorney Fees BK - Additional Court Appearance" }
]

// Response
{
    "euclideanDistance":0.8615474112856312,
    "sizeRight":984,
    "sizeLeft":735,
    "jaccardDistance":0.925625,
    "overlappingAll":119,
    "overlappingLeftRight":0.1619047619047619,
    "overlappingRightLeft":0.1209349593495935,
    "weightedScoring":25.231176418263615,
    "cosineSimilarity":0.13992835952535854
}

```

### Semantic_Compare_Bulk.xaml
Use Cortical.IO[https://www.cortical.io] to return a semantic comparison of an array of words.

**Arguments**   
    **IN**   
        *arr_json_word_touples* - An array of arrays. Each array contains 2 JSON objects with 1 field: "Text", which is the text you need to compare.   
    **OUT**   
        *arr_json_comparisons* - Returns an array of JSON objects. Each object corresponds to the to the input array. So arr_json_comparisons(0) is the result comparison of arr_json_words_touples(0).   
**Sample Output:**
```
// Request:
 
[
 
    [
        { "text":"Exterior Property Inspection" },
        { "text":"Attorney Fees BK - Additional Court Appearance" }
    ], 
    
    [
        { "text":"Attorney Fees BK - All Other Bankruptcy Fees" },
        { "text":"Exterior Property Inspection" }
    ] 
]


// Response:
[
    {
        "euclideanDistance":0.8615474112856312,
        "sizeRight":984,
        "sizeLeft":735,
        "jaccardDistance":0.925625,
        "overlappingAll":119,
        "overlappingLeftRight":0.1619047619047619,
        "overlappingRightLeft":0.1209349593495935,
        "weightedScoring":25.231176418263615,
        "cosineSimilarity":0.13992835952535854
   },       
   {
        "euclideanDistance":0.8615474112856312,
        "sizeRight":984,
        "sizeLeft":735,
        "jaccardDistance":0.925625,
        "overlappingAll":119,
        "overlappingLeftRight":0.1619047619047619,
        "overlappingRightLeft":0.1209349593495935,
        "weightedScoring":25.231176418263615,
        "cosineSimilarity":0.13992835952535854
  }
]

```