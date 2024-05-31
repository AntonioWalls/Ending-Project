import React, { useState, useEffect } from 'react';
import { Button, Form, Col, Row, Card } from 'react-bootstrap';
import { useDispatch } from 'react-redux';
import { addRealState, editRealState, getRealStateUnique } from '../../../redux/actions/ActionReal_State';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import Swal from "sweetalert2";

function FormReal_Estate({ showForm, idInmobiliaria }) {
    const initialRealStateState = {
        idInmobiliaria: 0,
        razonSocial: '',
        rfc: '',
        telefono: ''
    };

    const dispatch = useDispatch();
    const [realstate, setRealState] = useState({ initialRealStateState });

    useEffect(() => {
        if (idInmobiliaria > 0) {
            dispatch(getRealStateUnique(idInmobiliaria))
                .then((response) => {
                    setRealState(response.payload.response);
                });
        }
    }, [dispatch, idInmobiliaria]);

    const handleCancel = () => {
        setRealState(initialRealStateState);
        showForm();
    };

    const handleGuardar = () => {
            console.log(idInmobiliaria)
        if (idInmobiliaria > 0) {
            dispatch(editRealState(realstate)).then(() => {
                Swal.fire({
                    icon: "success",
                    title: "Editado con exito",
                    text: "Se ha guardado el registro con total exito",
                    showConfirmButton: false,
                    timer: 1500,
                });
            });
        } else {
            dispatch(addRealState(realstate)).then(() => {
                console.log(addRealState)
                console.log(idInmobiliaria)
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
                    <h1>Registro de Inmobiliaria</h1>
                </Card.Header>
                <Card.Body>
                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Razon Social : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="razonsocial"
                                value={realstate.razonSocial}
                                onChange={(e) => setRealState({ ...realstate, razonSocial: e.target.value })}
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
                                value={realstate.rfc}
                                onChange={(e) => setRealState({ ...realstate, rfc: e.target.value })}
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
                                value={realstate.telefono}
                                onChange={(e) => setRealState({ ...realstate, telefono: e.target.value })}
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

export default FormReal_Estate;

