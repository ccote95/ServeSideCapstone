const _apiUrl = "/api/placedorder"

export const placeOrder = (chosenCard, cart, id) => {
    return fetch (`${_apiUrl}?chosenCard=${chosenCard}&id=${id}`,{
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(cart)
    })
}