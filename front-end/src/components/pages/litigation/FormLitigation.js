import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Form, Col, Row, Card } from 'react-bootstrap';
import { getLitigationUnique, addLitigationState, editLitigation } from '../../../redux/actions/actionLitigation';
import { getLitigious } from '../../../redux/actions/actionLitigious';
import { getAuction } from '../../../redux/actions/actionAuction'
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import Swal from "sweetalert2";


function FormLitigation({ showForm, id }) {
    const initialUserState = {
        idLitigio: 0,
        idLitigioso: 0,
        idRemate: 0,
        procedimiento: '',
        juzgado: '',
        expediente: '',
        edoJuzgado: '',
        adeudoTotal: 0
    };

    const dispatch = useDispatch();

    const { litigious } = useSelector(state => state.getLitigious);
    const { auctions } = useSelector(state => state.getAuction);
    const [litigation, setLitigation] = useState({ initialUserState });

    useEffect(() => {
        dispatch(getLitigious());
    }, [dispatch]);

    useEffect(() => {
        dispatch(getAuction());
    }, [dispatch]);
    
    useEffect(() => {
        if (id > 0) {
            dispatch(getLitigationUnique(id))
                .then((response) => {
                    setLitigation(response.payload.response);
                });
        }
    }, [dispatch, id]);

    const handleCancel = () => {
        setLitigation(initialUserState);
        showForm();
    };

    const handleGuardar = () => {

        if (id > 0) {
            dispatch(editLitigation(litigation)).then(() => {
                Swal.fire({
                    icon: "success",
                    title: "Editado con exito",
                    text: "Se ha guardado el registro con total exito",
                    showConfirmButton: false,
                    timer: 1500,
                });
            });
        } else {
            dispatch(addLitigationState(litigation)).then(() => {
                console.log('Litigio guardado');
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
                    <h1>Registro de Litigio</h1>
                </Card.Header>
                <Card.Body>
                <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Litigioso: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Select
                                name="idLitigioso"
                                value={litigation.idLitigioso}
                                onChange={(e) => setLitigation({ ...litigation, idLitigioso: parseInt(e.target.value) })}>
                                <option value="0" disabled>Seleccione un Litigioso</option>
                                {/* Mostrar lista de inmobiliarias */}
                                {litigious.response && litigious.response.map((item) => (
                                    <option key={item.idLitigioso} value={item.idLitigioso}>{item.nombres}</option>
                                ))}
                            </Form.Select>
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Remate: </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Select
                                name="idRemate"
                                value={litigation.idRemate}
                                onChange={(e) => setLitigation({ ...litigation, idRemate: parseInt(e.target.value) })}>
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
                            <Form.Label>Procedimiento : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="procedimiento"
                                value={litigation.procedimiento}
                                onChange={(e) => setLitigation({ ...litigation, procedimiento: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Juzgado : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="juzgado"
                                value={litigation.juzgado}
                                onChange={(e) => setLitigation({ ...litigation, juzgado: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Expediente : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="expediente"
                                value={litigation.expediente}
                                onChange={(e) => setLitigation({ ...litigation, expediente: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Estado Juzgado : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="edoJuzgado"
                                value={litigation.edoJuzgado}
                                onChange={(e) => setLitigation({ ...litigation, juzgado: e.target.value })}
                            />
                        </Col>
                    </Row>
                    <br />

                    <Row>
                        <Col lg={5} sm={12} xl={6}>
                            <Form.Label>Adeudo Total : </Form.Label>
                        </Col>
                        <Col lg={7} sm={12} xl={6}>
                            <Form.Control
                                type="text"
                                name="adeudoTotal"
                                value={litigation.adeudoTotal}
                                onChange={(e) => setLitigation({ ...litigation, adeudoTotal: e.target.value })}
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

export default FormLitigation;
