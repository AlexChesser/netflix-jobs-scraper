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

### update

actually don't bother with csv2html, just run the main HTML thing on the full jobs bank and filter / sort as you like on page.

click the checkbox on page to mark the ones you want to reread or follow up on.


### another update

new feature written out of interest. what do ALL the requirements look like of all open roles?

run `dotnet run req` to build a list of every bullet point. maybe there's something of value there. (mildly interesting if you sort, needs more work maybe run it against a word-cloud or something)

Also a unit test was added to build that, so you can run the tests by typing `dotnet test` on the command line.

that does mean that to actually run the downloader it is easier to change directory to the src subfolder.
