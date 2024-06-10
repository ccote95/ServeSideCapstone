import { useParams } from "react-router-dom"
import PageContainer from "../PageContainer.jsx"
import { Badge, Button, Card, CardBody, CardImg, CardImgOverlay } from "reactstrap"
import { useEffect, useState } from "react"
import {  getListingById } from "../../managers/listingManger.js"

export default function ListingDetails({loggedInUser})
{

    const [listing, setListing] = useState()
   

    const {id} = useParams()

    useEffect(() => {
        getListingById(parseInt(id)).then(setListing)
    },[])

    return(
       <PageContainer>
            <Card className="shadow" style={{width: "60%"}}>
                <CardImg
                    className="w-25 m-auto rounded mt-1"
                    alt="Listing Header Image"
                    src={listing?.productImg}
                />
                <CardImgOverlay>
                    <Badge className="fs-4 "pill>
                        {listing?.title}
                    </Badge>
                    <Badge style={{float: "right"}}>
                        {listing?.formattedDate}
                    </Badge>
                    <div className="pe-auto fs-3">
                        <Badge pill>
                            {listing?.userProfile.fullName}
                        </Badge>
                    </div>
                  {listing?.categories.map((c) => (
                    <div className="pe-auto fs-5" key={c.id}>
                        <Badge pill>
                            {c.name}
                        </Badge>
                    </div>
                  ))}
                  <div className="pe-auto">
                        <Badge pill>
                            ${listing?.price}
                        </Badge>
                    </div>
                </CardImgOverlay>
                <CardBody className=" m-auto">
                    {listing?.content}
                </CardBody>
               <div className="d-flex flex-row flex-wrap mt-3 w-100 gap-2 justify-content-md-end " >
               <Button className="me-2 mb-1">
                    Edit
                </Button>
                {listing?.userProfile.id == loggedInUser.id && (
                <Button className="me-2 mb-1">
                    DELETE
                </Button>

                )}
               </div>
            </Card>
       </PageContainer>
    )
}

//getListingById returns invalid json for some reason. need to ask someone about that