import { Card, CardBody, Col, Container, Row } from "reactstrap";

export default function LandingPage()
{
    return(
        <Container className="d-flex vh-100">
        <Row className="m-auto">
          <Col md="12">
            <Card className="text-center">
              <CardBody>
                <h1>Welcome To capstone</h1>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </Container>
    )
}