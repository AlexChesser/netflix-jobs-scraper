# Netflix Jobs downloader

browsing the default netflix jobs site for new SSE roles is a pain. This quick little script allows for a full search of Senior Software Engineer roles to be downloaded locally and searched for roles that are a good fit.

## usage:

download all jobs to store them locally (don't overuse to prevent getting deny listed)
`dotnet run d`

create an EXCEL sheet for marking up roles (download first)

`dotnet run csv`

create an HTML table for reading the roles' html (download first)

`dotnet run html`

note that `csv` and `html`are mutually exclusive but this can be executed in one step by running:

`dotnet run d csv` or `dotnet run d html`


### Getting a filtered list of relevant postings

after downloading the CSV, open in excel to sort and filter on fields of interest. (eg: location, age of posting) and save the file retaining tab delimited (text) format.

execute the command:

`dotnet run csv2html`

and the filtered list will be converted to human readable HTML.

Loading that HTML into a word document will allow the user to make notes regarding preferences.