import React, { useState, useEffect } from 'react';
import { Button, Form, Col, Row, Card } from 'react-bootstrap';
import { useDispatch } from 'react-redux';
import { addProperty, editProperty, getPropertyUnique } from '../../../redux/actions/actionProperty';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import Swal from "sweetalert2";

function FormProperty({ showForm, id }) {
    const initialRealStateState = {
        idPropiedad: 0,
        num: '',
        colonia: '',
        municipio: '',
        estado: '',
        cp: 0,
        subtipo: '',
        latitud: 0,
        altitud: 0,
        superficieTerreno: 0,
        superficieCons: 0
    };

    const dispatch = useDispatch();
    const [property, setProperty] = useState({ initialRealStateState });

    useEffect(() => {
        if (id > 0) {
            dispatch(getPropertyUnique(id))
                .then((response) => {
                    setProperty(response.payload.response);
                });
        }
    }, [dispatch, id]);

    const handleCancel = () => {
        setProperty(initialRealStateState);
        showForm();
    };

    const handleGuardar = () => {
            console.log(id)
        if (id > 0) {
            dispatch(editProperty(property)).then(() => {
                Swal.fire({
                    icon: "success",
                    title: "Editado con exito",
                    text: "Se ha guardado el registro con total exito",
                    showConfirmButton: false,
                    timer: 1500,
                });
            });
        } else {
            dispatch(addProperty(property)).then(() => {
                console.log('Propiedad guardado');
                Swal.fire({
                    icon: "success",
                    title: "Guardado con exito",
                    text: "Se ha guardado el registro con total exito",
                    showConfirmButton: false,
                    timer: 1500,
                });
            })
        }
    };

    return (
        <Col lg={6} xs={12} sm={8}>
            <Card>
                <Card.Header>
                    <h1>Registro de Propiedad</h1>
                </Card.Header>
                <Card.Body>
                <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Calle: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="calle"
                                value={property.calle}
                                onChange={(e) => setProperty({ ...property, calle: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Numero: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="num"
                                value={property.num}
                                onChange={(e) => setProperty({ ...property, num: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Colonia: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="colonia"
                                value={property.colonia}
                                onChange={(e) => setProperty({ ...property, colonia: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Municipio: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="municipio"
                                value={property.municipio}
                                onChange={(e) => setProperty({ ...property, municipio: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Estado: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="estado"
                                value={property.estado}
                                onChange={(e) => setProperty({ ...property, estado: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Codigo Postal: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="cp"
                                value={property.cp}
                                onChange={(e) => setProperty({ ...property, cp: e.target.value })}
                            />
                        </Col>
                    </Row>
  
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Subtipo: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="subtipo"
                                value={property.subtipo}
                                onChange={(e) => setProperty({ ...property, subtipo: e.target.value })}
                            />
                        </Col>
                    </Row>

                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Latitud: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="latitud"
                                value={property.latitud}
                                onChange={(e) => setProperty({ ...property, latitud: e.target.value })}
                            />
                        </Col>
                    </Row>

                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Altitud: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="altitud"
                                value={property.altitud}
                                onChange={(e) => setProperty({ ...property, altitud: e.target.value })}
                            />
                        </Col>
                    </Row>

                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Superficie de Terreno: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="superficieTerreno"
                                value={property.superficieTerreno}
                                onChange={(e) => setProperty({ ...property, superficieTerreno: e.target.value })}
                            />
                        </Col>
                    </Row>

                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Superficie de Construccion: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="superficieCons"
                                value={property.superficieCons}
                                onChange={(e) => setProperty({ ...property, superficieCons: e.target.value })}
                            />
                        </Col>
                    </Row>
  
                    <br />

                </Card.Body>
                <Card.Footer>
                    <Button variant='danger' onClick={handleCancel} className='m-1'>Cancelar</Button>
                    <Button variant='primary' onClick={handleGuardar}>Guardar</Button>
                </Card.Footer>
            </Card>
        </Col>
    );
}

export default FormProperty;
