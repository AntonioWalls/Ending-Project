import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Form, Col, Row, Card } from 'react-bootstrap';
import { addAwarded, getAwardedUnique, editAwarded } from '../../../redux/actions/actionAwarded';
import { getAuction } from '../../../redux/actions/actionAuction';
import 'react-datepicker/dist/react-datepicker.css';
import Swal from "sweetalert2";

function FormAwarded({ showForm, id }) {
    const initialUserState = {
        idAdjudicado: 0,
        idRemate: 0,
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
        cp: 0,
        semafonoEscrituracion: '',
        consideraciones: '',
        estadoAdjudicacion: true,
    };

    const dispatch = useDispatch();

    const { auctions } = useSelector(state => state.getAuction);
    const [awarded, setAwarded] = useState({ initialUserState });

    useEffect(() => {
        dispatch(getAuction());
    }, [dispatch]);
    

    useEffect(() => {
        if (id > 0) {
            dispatch(getAwardedUnique(id))
                .then((response) => {
                    setAwarded(response.payload.response);
                });
        }
    }, [dispatch, id]);

    const handleCancel = () => {
        setAwarded(initialUserState);
        showForm();
    };

    const handleGuardar = () => {

        if (id > 0) {
            dispatch(editAwarded(awarded)).then(() => {
                Swal.fire({
                    icon: "success",
                    title: "Editado con exito",
                    text: "Se ha guardado el registro con total exito",
                    showConfirmButton: false,
                    timer: 1500,
                });
            });
        } else {
            dispatch(addAwarded(awarded)).then(() => {
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
                    <h1>Registro de Adjudicado</h1>
                </Card.Header>
                <Card.Body>
                <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Remate: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Select
                                name="idRemate"
                                value={awarded.idRemate}
                                onChange={(e) => setAwarded({ ...awarded, idRemate: parseInt(e.target.value) })}>
                                <option value="0" disabled>Seleccione un Remate</option>
                                {/* Mostrar lista de inmobiliarias */}
                                {auctions.response && auctions.response.map((item) => (
                                    <option key={item.idRemate} value={item.idRemate}>{item.descripcion}</option>
                                ))}
                            </Form.Select>
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Nombre : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="nombre"
                                value={awarded.nombres}
                                onChange={(e) => setAwarded({ ...awarded, nombres: e.target.value })}
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
                                value={awarded.apellidos}
                                onChange={(e) => setAwarded({ ...awarded, apellidos: e.target.value })}
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
                                value={awarded.rfc}
                                onChange={(e) => setAwarded({ ...awarded, rfc: e.target.value })}
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
                                value={awarded.curp}
                                onChange={(e) => setAwarded({ ...awarded, curp: e.target.value })}
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
                                value={awarded.telefono}
                                onChange={(e) => setAwarded({ ...awarded, telefono: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Calle: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="calle"
                                value={awarded.calle}
                                onChange={(e) => setAwarded({ ...awarded, calle: e.target.value })}
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
                                value={awarded.num}
                                onChange={(e) => setAwarded({ ...awarded, num: e.target.value })}
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
                                value={awarded.colonia}
                                onChange={(e) => setAwarded({ ...awarded, colonia: e.target.value })}
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
                                value={awarded.municipio}
                                onChange={(e) => setAwarded({ ...awarded, municipio: e.target.value })}
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
                                value={awarded.estado}
                                onChange={(e) => setAwarded({ ...awarded, estado: e.target.value })}
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
                                value={awarded.cp}
                                onChange={(e) => setAwarded({ ...awarded, cp: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Semafono de Escrituracion: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="semafonoEscrituracion"
                                value={awarded.semafonoEscrituracion}
                                onChange={(e) => setAwarded({ ...awarded, semafonoEscrituracion: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Consideraciones: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type='text'
                                name="consideraciones"
                                value={awarded.consideraciones}
                                onChange={(e) => setAwarded({ ...awarded, consideraciones: e.target.value })}
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

export default FormAwarded;

