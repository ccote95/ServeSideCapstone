import { useEffect, useState } from "react"
import { getById } from "../../managers/userProfileManager.js"
import PageContainer from "../PageContainer.jsx"
import { Button, Card,CardBody,CardImg,CardText,Label } from "reactstrap"
import { useNavigate } from "react-router-dom"

export default function MyProfile({loggedInUser})
{
    const [user, setUser] = useState()

    const navigate = useNavigate()

    useEffect(() => {
        getById(loggedInUser.id).then(setUser)
    },[])
    return(
    <PageContainer>
        <Card className="w-25 shadow">
            <CardText className="m-auto fs-2">{user?.identityUser.userName}</CardText>
            <img src={user?.imgLocation}/>
            <CardBody>
                <Label className="fw-bold fs-5">First Name:</Label>
                <CardText className="fs-5">{user?.firstName}</CardText>
                <Label className="fw-bold fs-5">Last Name:</Label>
                <CardText className="fs-5">{user?.lastName}</CardText>
                <Label className="fw-bold fs-5">Email:</Label>
                <CardText className="fs-5">{user?.identityUser.email}</CardText>
                <Label className="fw-bold fs-5">Address:</Label>
                <CardText className="fs-5">{user?.address}</CardText>
            </CardBody>
            <div className="d-flex gap-2 justify-content-end mb-1 me-1" >
                <Button onClick={() => {navigate(`/myProfile/edit`)}}>Edit</Button>
                <Button>Payment Info</Button>
            </div>
        </Card>
    </PageContainer>
    )
}