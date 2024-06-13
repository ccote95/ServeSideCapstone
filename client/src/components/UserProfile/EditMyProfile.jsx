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
    const [selectedFile, setSelectedFile] = useState()
    


    useEffect(() => {
        getById(loggedInUser.id).then(user => {
            setFirstName(user.firstName)
            setLastName(user.lastName)
            setAddress(user.address)
        })
    },[])

    const handleSave = () => {
        e.preventDefault()

        const formData = new FormData();
        formData.append("image", selectedFile)
        formData.append("firstName", firstName)
        formData.append("lastName", lastName)
        formData.append("address", address)
    }


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
                 <Label className="fw-bold fs-5">Profile Image:</Label>
                 <Input
                    type="file"
                    onChange={(e) => {setSelectedFile(e.target.value)}}
                />
                    
            </CardBody>
            <div className="d-flex gap-2 justify-content-end mb-1 me-1" >
                <Button onClick={handleSave}>Save</Button>
                <Button>Cancel</Button>
            </div>
        </Card>
    </PageContainer>
    )
}