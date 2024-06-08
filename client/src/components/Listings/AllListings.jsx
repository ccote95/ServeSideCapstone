import { useEffect, useState } from "react"
import { getAll } from "../../managers/listingManger.js"

export default function AllListings()
{
    const [listings, setListings] = useState([])


    useEffect(() => {
        getAll().then(setListings)
    },[])
    return(
        <div>hello</div>
    )
}
