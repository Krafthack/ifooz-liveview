# ifooz-liveview

POST:
/game/publish

Example usage:
```

var obj = {
  "Blue": {
    "Players": [
      {
        "Id": 0,
        "Name": "Name"
      }
    ],
    "Goals": [
      {
        "Timestamp": "2015-06-15T11:42:52.2734554+02:00"
      }
    ]
  },
  "White": {
    "Players": [
      {
        "Id": 2,
        "Name": "Name"
      }

    ],
    "Goals": [
      {
        "Timestamp": "2015-06-15T11:39:01.2744558+02:00"
      }
    ]
  },
  "StartTime": "2015-06-15T11:38:42.2744558+02:00"
}

$.ajax({
  type: "POST",
  url: "game/publish",
  data: JSON.stringify(obj),
  contentType: "application/json",
  dataType: "json" 
});

```
