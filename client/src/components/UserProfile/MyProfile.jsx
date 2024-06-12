import { useEffect, useState } from "react"
import { getById } from "../../managers/userProfileManager.js"
import PageContainer from "../PageContainer.jsx"
import { Button, ButtonGroup, ButtonToolbar, Card, CardBody, CardImg, CardText, Input, Label } from "reactstrap"

export default function MyProfile({loggedInUser})
{
    const [user, setUser] = useState()

    useEffect(() => {
        getById(loggedInUser.id).then(setUser)
    },[])
    return(
    <PageContainer>
        <Card className="w-25 shadow">
            <CardText className="m-auto fs-2">{user?.identityUser.userName}</CardText>
            <CardBody>
                <Label className="fw-bold">First Name:</Label>
                <CardText>{user?.firstName}</CardText>
                <Label className="fw-bold">Last Name:</Label>
                <CardText>{user?.lastName}</CardText>
                <Label className="fw-bold">Email:</Label>
                <CardText>{user?.identityUser.email}</CardText>
                <Label className="fw-bold">Address:</Label>
                <CardText>{user?.address}</CardText>
            </CardBody>
            <div className="d-flex gap-2 justify-content-end mb-1 me-1" >
            <Button>Edit</Button>
            <Button>Payment Info</Button>
            </div>
        </Card>
    </PageContainer>
    )
}