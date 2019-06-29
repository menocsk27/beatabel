## api url: beatabelapi.herokuapp.com


### Methods available:

### `/createAutomatedTimestamps/`
Generates Timestamps and returns a JSON object with either tempo or timestamps depending on `mode`. Doesn't save generated timestamps in database as well.

<br>

**content type**: _multipart/form-data_
#### Params:

| Name | Type | Value | Description |
|-|-|-|-|
| `song` | `file` | Audio from disk | Choose an audio file from your disk for processing |
| `mode` | `text` | `0` or `1` | `0`: Get timestamps <br> `1`: Get tempo |
| `save` | `text` | `0` or `1` | `0`: Do not save timestamps <br> `1`: Save timestamps <br>Saving is not possible for _tempo_ mode|

### `/getSongs/`
Get the list of songs whose timestamps are stored in database

### `/createTimestamps/`
Not API but a webpage for manual timestamp creation. Choose a song and click "Start tapping". 
Then press any key to save that timestamp. When done, pause the song and click "Save Timestamps" to save timestamps.