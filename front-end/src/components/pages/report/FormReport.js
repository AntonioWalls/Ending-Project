import 'bootstrap/dist/css/bootstrap.min.css';
import React, { useState } from 'react';
import DatePicker from 'react-datepicker';
import { Button, Form, Col, Row, FormLabel } from 'react-bootstrap';
import Swal from "sweetalert2";

export default function FormReport({ showForm, initialDate, ultimateDate }) {
  const [startDate, setStartDate] = useState(new Date()); // Estado para la fecha seleccionada
  const [finalDate, setFinalDate] = useState(new Date()); // Estado para la fecha seleccionada

  const handleReport = () => {
    if (startDate.getTime() === finalDate.getTime()) {
      Swal.fire({
        icon: "error",
        title: "Error",
        text: "Ambas fechas son iguales",
      });
    } else if (startDate.getTime() > finalDate.getTime()) {
      Swal.fire({
        icon: "error",
        title: "Error",
        text: "La fecha inicial es mayor a la fecha final",
      });
    } else {
      initialDate(startDate);
      ultimateDate(finalDate);
      showForm();
    }
  };

  return (
    <div>
      <Row>
        <Col lg={2} sm={2} xl={2}>
          <FormLabel>Fecha Inicial: </FormLabel>
        </Col>
        <Col>
          <DatePicker
            selected={startDate}
            onChange={(date) => setStartDate(date)}
          />
        </Col>

        <Col>
          <FormLabel>Fecha final: </FormLabel>
        </Col>
        <Col>
          <DatePicker
            selected={finalDate}
            onChange={(date) => setFinalDate(date)}
          />
        </Col>
      </Row>
      <Row>
        <Col>
          <FormLabel>Del {startDate.toDateString()} al {finalDate.toDateString()}</FormLabel>
        </Col>
      </Row>
      <Row>
        <Button variant='danger' onClick={handleReport} className='m-1'>Generar Reporte</Button>
      </Row>
    </div>
  );
}