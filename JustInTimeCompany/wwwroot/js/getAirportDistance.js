export function getAirportDistance(fromAirId, toAirId, url, token) {
    let params = `?toId=${fromAirId}&Landing=${toAirId}`;

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
        .then(response => response)
}