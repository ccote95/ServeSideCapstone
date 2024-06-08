import { useEffect, useState } from "react"
import { getAll } from "../../managers/listingManger.js"
import { Card, CardBody, CardImg, CardTitle } from "reactstrap"

export default function AllListings()
{
    const [listings, setListings] = useState([])


    useEffect(() => {
        getAll().then(setListings)
    },[])

    return(
        <>
        {listings.map((l) => (
            <Card className="w-50 m-auto"  style={{maxWidth: "1200px"}}>
                <CardImg
                className="w-25 rounded"
                src={l.productImg}/>
                <CardTitle>
                    {l.userProfile.fullName}
                </CardTitle>
                <CardBody>
                    {l.content}
                </CardBody>
            </Card>
        ))}
        </>
    )
}
