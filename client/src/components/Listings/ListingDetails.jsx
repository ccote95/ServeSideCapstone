import { useNavigate, useParams } from "react-router-dom"
import PageContainer from "../FlexContainer.jsx"
import { Badge, Button, Card, CardBody, CardImg, CardImgOverlay } from "reactstrap"
import { useEffect, useState } from "react"
import {  deleteListing, getListingById } from "../../managers/listingManger.js"

export default function ListingDetails({loggedInUser})
{

    const [listing, setListing] = useState()
   
    const navigate = useNavigate()

    const {id} = useParams()

    useEffect(() => {
        getListingById(parseInt(id)).then(setListing)
    },[])

    const handleDelete = (id) => {
        deleteListing(parseInt(id)).then(() => {navigate("/listings")})
    }

    return(
       <PageContainer>
            <Card className="shadow" style={{width: "60%"}}>
            {!listing?.imageBlob ? (
                    <CardImg
                        src={listing?.productImg}
                    />
                ) : (
                    <CardImg src={`data:image/jpeg;base64,${listing?.imageBlob}`} />
                )}
                <CardImgOverlay className="pe-none">
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
                    <div className="w-25 pe-auto fs-5" key={c.id}>
                        <Badge className="pe-none" pill>
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
                
                {listing?.userProfile.id == loggedInUser.id && (
                    <>
                <Button className="me-2 mb-1"
                onClick={() => {handleDelete(listing.id)}}>
                    DELETE
                </Button>
               <Button className="me-2 mb-1"
               onClick={() => {navigate("edit")}}>
                    Edit
                </Button>
                </>
                )}
               </div>
            </Card>
       </PageContainer>
    )
}

//getListingById returns invalid json for some reason. need to ask someone about that