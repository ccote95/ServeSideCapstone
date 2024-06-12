const _api = "/api/listing"

export const getAll = () => {
return fetch(_api).then(res => res.json())
}

export const getAllListingsById = (userId) => {
    return fetch(`${_api}/listing/${userId}`).then(res => res.json());
}

export const getListingById = (id) => {
    return fetch(`${_api}/${id}`).then(res => res.json())
}

export const createListing = (listing) => {
    console.log('createListing called with:', listing);

    return fetch("/api/listing", {
        method: "POST",
        body: listing
    })
};

export const deleteListing = (id) => {
    return fetch(`${_api}/${id}`,{
        method: "DELETE"
    })
}

export const updateListing = (id,updateListing) => {
    return fetch(`${_api}/${id}`,{
        method: "PUT",
        body: updateListing
    })
}