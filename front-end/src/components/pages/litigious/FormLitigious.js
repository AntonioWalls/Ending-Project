import React, { useState, useEffect } from 'react';
import { Button, Form, Col, Row, Card } from 'react-bootstrap';
import { useDispatch } from 'react-redux';
import { addLitigious, editLitigious, getLitigiousUnique } from '../../../redux/actions/actionLitigious';
import 'react-datepicker/dist/react-datepicker.css';
import Swal from "sweetalert2";

function FormLitigious({ showForm, id }) {
    const initialUserState = {
        idLitigioso: 0,
        nombres: '',
        apellidos: '',
        rfc: '',
        curp: '',
        telefono: '',
        calle: '',
        num: 0,
        colonia: '',
        municipio: '',
        estado: '',
        cp: 0
    };

    const dispatch = useDispatch();
    const [litigiousUnique, setLitigiousUnique] = useState({ initialUserState });

    useEffect(() => {
        if (id > 0) {
            dispatch(getLitigiousUnique(id))
                .then((response) => {
                    setLitigiousUnique(response.payload.response);
                });
        }
    }, [dispatch, id]);

    const handleCancel = () => {
        setLitigiousUnique(initialUserState);
        showForm();
    };

    const handleGuardar = () => {
        console.log(id)
        if (id > 0) {
            dispatch(editLitigious(litigiousUnique)).then(() => {
                Swal.fire({
                    icon: "success",
                    title: "Editado con exito",
                    text: "Se ha guardado el registro con total exito",
                    showConfirmButton: false,
                    timer: 1500,
                });
            });
        } else {
            dispatch(addLitigious(litigiousUnique)).then(() => {
                console.log('Usuario guardado');
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
                    <h1>Registro de Litigioso</h1>
                </Card.Header>
                <Card.Body>
                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Nombre : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="nombre"
                                value={litigiousUnique.nombres}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, nombres: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Apellidos : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="apellidos"
                                value={litigiousUnique.apellidos}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, apellidos: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>RFC : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="rfc"
                                value={litigiousUnique.rfc}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, rfc: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>CURP : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="curp"
                                value={litigiousUnique.curp}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, curp: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />


                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Telefono : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="telefono"
                                value={litigiousUnique.telefono}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, telefono: e.target.value })}
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
                                value={litigiousUnique.num}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, num: e.target.value })}
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
                                value={litigiousUnique.colonia}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, colonia: e.target.value })}
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
                                value={litigiousUnique.municipio}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, municipio: e.target.value })}
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
                                value={litigiousUnique.estado}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, estado: e.target.value })}
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
                                value={litigiousUnique.cp}
                                onChange={(e) => setLitigiousUnique({ ...litigiousUnique, cp: e.target.value })}
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

export default FormLitigious;
