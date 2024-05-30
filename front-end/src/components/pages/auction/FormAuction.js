import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Form, Col, Row, Card } from 'react-bootstrap';
import { addAuction, editAuction, getAuctionUnique } from '../../../redux/actions/actionAuction';
import { getRealState } from '../../../redux/actions/ActionReal_State';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import Swal from "sweetalert2";

function FormAuction({ showForm, id }) {
    const initialUserState = {
        idRemate: 0,
        idInmobiliaria: 0,
        fiscalia: '',
        estado: true,
        fecha: '',
        descripcion: ''
    };

    const [realstates, setRealStates] = useState(state => state.getRealState);

    useEffect(() => {
        dispatch(setRealStates(getRealState));
    }, [dispatch]);
    
    const dispatch = useDispatch();

    const [auction, setAuction] = useState({ initialUserState });


    useEffect(() => {
        if (id > 0) {
            dispatch(getAuctionUnique(id))
                .then((response) => {
                    setAuction(response.payload.response);
                });
        }
    }, [dispatch, id]);

    const handleCancel = () => {
        setAuction(initialUserState);
        showForm();
    };

    const handleGuardar = () => {

        if (id > 0) {
            dispatch(editAuction(auction)).then(() => {
                console.log('si')
            });
        } else {
            dispatch(addAuction(auction)).then(() => {
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
                    <h1>Registro de Remates</h1>
                </Card.Header>
                <Card.Body>
                <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Inmobiliaria: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Select
                                name="idInmobiliaria"
                                value={auction.idInmobiliaria}
                                onChange={(e) => setAuction({ ...auction, idInmobiliaria: parseInt(e.target.value) })}>
                                <option value={"0"} disabled>Seleccione una Inmobiliaria</option>
                                {/* Mostrar lista de inmobiliarias */}
                                {realstates ? (realstates.map((item) => () => {
                                    return (
                                        <option value={item.idInmobiliaria} >{item.razonSocial}</option>
                                    );
                                })) : null}

                            </Form.Select>
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Fiscalia : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="fiscalia"
                                value={auction.fiscalia}
                                onChange={(e) => setAuction({ ...auction, fiscalia: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Fecha: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <DatePicker
                                className='form-control'
                                selected={auction.fecha}
                                onChange={(date) => setAuction({ ...auction, fecha: date })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Descripcion : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="descripcion"
                                value={auction.descripcion}
                                onChange={(e) => setAuction({ ...auction, descripcion: e.target.value })}
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

export default FormAuction;
