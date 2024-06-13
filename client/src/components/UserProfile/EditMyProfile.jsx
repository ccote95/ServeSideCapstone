import { useEffect, useState } from "react"

import { getById } from "../../managers/userProfileManager.js"
import PageContainer from "../PageContainer.jsx"
import { Button, Card, CardBody, CardText, Input, Label } from "reactstrap"

export default function EditMyProfile({loggedInUser})
{
    const [user,setUser] = useState({})
    const [firstName, setFirstName] = useState()
    const [lastName, setLastName] = useState()
    const [address, setAddress] = useState()
    


    useEffect(() => {
        getById(loggedInUser.id).then(user => {
            setFirstName(user.firstName)
            setLastName(user.lastName)
            setAddress(user.address)
        })
    },[])


    return(
        <PageContainer>
        <Card className="w-25 shadow">
            <CardText className="m-auto fs-2">{user?.identityUser?.userName}</CardText>
            <CardBody>
                <Label className="fw-bold fs-5">First Name:</Label>
                <Input
                    type="text"
                    value={firstName}
                    onChange={(e) => {setFirstName(e.target.value)}}
                />
                <Label className="fw-bold fs-5">Last Name:</Label>
                <Input
                    type="text"
                    value={lastName}
                    onChange={(e) => {setLastName(e.target.value)}}
                />
                <Label className="fw-bold fs-5">Address:</Label>
                <Input
                    type="text"
                    value={address}
                    onChange={(e) => {setAddress    (e.target.value)}}
                />
            </CardBody>
            <div className="d-flex gap-2 justify-content-end mb-1 me-1" >
                <Button>Save</Button>
            </div>
        </Card>
    </PageContainer>
    )
}