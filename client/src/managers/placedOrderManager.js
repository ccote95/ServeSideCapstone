const _apiUrl = "/api/placeOrder"

export const placeOrder = (chosenCard, cart) => {
    return fetch (`${_apiUrl}?chosenCard=${chosenCard}`,{
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(cart)
    })
}