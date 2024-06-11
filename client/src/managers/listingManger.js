const _api = "/api/listing"

export const getAll = () => {
return fetch(_api).then(res => res.json())
}

export const getListingById = (id) => {
    return fetch(`${_api}/${id}`).then(res => res.json())
}

export const createListing = (listing) => {
    console.log('createListing called with:', listing);

    return fetch("/api/listing", {
        method: "POST",
        body: listing
    }).then(response => {
        if (!response.ok) {
            return response.text().then(text => {
                console.error('Response text:', text);
                throw new Error('Network response was not ok');
            });
        }
        return response.json();
    }).catch((e) => {
        console.error('There was a problem with the fetch operation:', e);
        throw e;
    });
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