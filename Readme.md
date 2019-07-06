## API url: beatabelapi.herokuapp.com


### Methods available:

### `/createAutomatedTimestamps/`
**content type**: _multipart/form-data_ <br>
**response type**: _JSON object_ <br>
**Description:** Generates Timestamps and returns a JSON object with either tempo or timestamps depending on `mode`. Doesn't save generated timestamps in database as well.



#### Params:

| Name | Type | Value | Description |
|-|-|-|-|
| `song` | `file` | Audio from disk | Choose an audio file from your disk for processing |
| `mode` | `text` | `0` or `1` | `0`: Get timestamps <br> `1`: Get tempo |
| `save` | `text` | `0` or `1` | `0`: Do not save timestamps <br> `1`: Save timestamps <br>Saving is not possible for _tempo_ mode|
| `getDelta`(optional) | `text` | `0` or `1`| `0`: Do not do anything. Equivalent to removing this paramenter <br> `1`: Get time differences between each timestamp element in a timestamp array |

### `/getSongs/`

**response type**: JSON object<br>
**Desription**: Get the list of songs whose timestamps are stored in database
#### Header Params:
| Name | Type | Value | Description |
|-|-|-|-|
| `getDelta`(optional) | `text` | `0` or `1`| `0`: Do not do anything. Equivalent to removing this paramenter <br> `1`: Get time differences between each timestamp element in a timestamp array |

### `/createTimestamps/`
**response type**: _JSON but not suitable for API calls_  `Please don't use for API calls`
**Desription**: Does not return any query results. Not API method but a webpage URL for manual timestamp creation. <br>Choose a song and click "Start tapping". Then press any key to save that timestamp. When done, pause the song and click "Save Timestamps" to save timestamps.