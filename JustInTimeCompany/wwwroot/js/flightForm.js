function getDistance(fromAirId, toAirId, url, token) {
    let params = `?toId=${fromAirId}&fromId=${toAirId}`;

    return fetch(url + params,
        {
            method: 'get',
            headers: {
                "Content-Type": "application/json; charset=utf-8",
                "RequestVerificationToken": token
            }
        })
        .then(response => {
            if (!response.ok) {
                throw new Error(`[${response.status}]: ${response.statusText} `);
            }
            return response;
        })
        .then(response => response.json());
};

function getPilots(landing, takeoff, url, token) {
    let params = `?TakeOff=${landing}&Landing=${takeoff}`;
    return fetch(url + params,
        {
            method: 'get',
            headers: {
                "Content-Type": "application/json; charset=utf-8",
                "RequestVerificationToken": token
            }
        })
        .then(response => {
            if (!response.ok) {
                throw new Error(`[${response.status}]: ${response.statusText} `);
            }
            return response;
        })
        .then(response => response.json());
};