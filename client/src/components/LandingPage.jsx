import { useEffect, useState } from "react";
import { Card, CardBody, Col, Container, Row } from "reactstrap";
import { getById } from "../managers/userProfileManager.js";

export default function LandingPage({loggedInUser})
{
    const [user, setUser] = useState()

    useEffect(() => {
        getById(loggedInUser.id).then(setUser)
    },[])
    return(
        <Container className="d-flex vh-100">
        <Row className="m-auto" >
          <Col md="12">
            <Card className="text-center shadow" >
              <CardBody className="m-5">
                <h1>Welcome {user?.fullName}!</h1>
                <h1>To ChadsList</h1>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </Container>
    )
}