import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState, useRef, useCallback } from 'react';
import * as React from "react";
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Col, Row, FormLabel } from "react-bootstrap";
import { AgGridReact } from 'ag-grid-react'; // AG Grid Component
import { getLitigation, deleteLitigation } from '../../../redux/actions/actionLitigation';
import Swal from "sweetalert2";

export default function TableLitigation({ showForm, idUserEdit }) {

  const [userSelected, setUserSelected] = React.useState(false);
  const [selectedState, setSelectedState] = React.useState({});

  // Rellenar grid con datos
  const dispatch = useDispatch();
  const { litigations } = useSelector((state) => state.getLitigation);


 // Obtener la id del usuario. 
 const [id, setId] = useState(0);
 const gridRef = useRef();
 const onSelectionChanged = useCallback(() => {
   const selectedRows = gridRef.current.api.getSelectedRows();
   if (selectedRows.length === 1) {
     document.querySelector("#selectedRows").innerHTML = selectedRows[0].procedimiento;
     setId(selectedRows[0].idLitigio);
   } else {
     document.querySelector("#selectedRows").innerHTML = "";
     setId(0);  // Reset id if no row or multiple rows are selected
   }
   console.log(id);
 }, [id]);



  useEffect(() => {
    dispatch(getLitigation());
  }, [dispatch]);

  // Column Definitions: Defines the columns to be displayed.
  const [colDefs, setColDefs] = useState([
    { field: 'idLitigio', headerName: 'ID de Litigio' },
    { field: 'idLitigioso', headerName: 'ID de Litigioso' },
    { field: 'idRemate', headerName: 'ID de Remate' },
    { field: 'procedimiento', headerName: 'Procedimiento' },
    { field: 'juzgado', headerName: 'Juzgado' },
    { field: 'expediente', headerName: 'Expediente' },
    { field: 'edoJuzgado', headerName: 'Estado Juzgado' },
    { field: 'adeudoTotal', headerName: 'Adeudo Total' }
  ]);


  const handleNew = () => {
    showForm();
    idUserEdit(0);
  };

  // const handleEdit = () => {
  //   if (id) {
  //     idUserEdit(id);
  //     showForm();
  //   } else {
  //     alert('Seleccione un usuario para modificar');
  //   }
  // };

  const handleEdit = () => {
      console.log(id);
      if(id){
          idUserEdit(id);
          showForm();
      }else{
          alert('Seleccione un litigio para modificar');
      }
  };

  const handleDelete = () => {

    if (id) {
      // Eliminar usuario seleccionado
      dispatch(deleteLitigation(id)).then(() => {
        Swal.fire({
          icon: "success",
          title: "Litigio eliminado",
          showConfirmButton: false,
          timer: 1500,
        }).then(() => {
          dispatch(getLitigation());
        });
      });
    } else {
      Swal.fire({
        icon: "error",
        title: "Error",
        text: "Seleccione un litigio para eliminar",
      });
      }
    // console.log(id);
    // if (id) {
    //   // Eliminar usuario seleccionado
    //   dispatch(deleteRealState(id))
    //     .then(() => {
    //       window.location.href = window.location.href;
    //     })
    // } else {
    //   alert("Seleccione un usuario para eliminar");
    // }
  };


  // ...

  return (

    // wrapping container with theme & size
    <div
      className="ag-theme-quartz" // applying the grid theme
      style={{ height: 500, width: 1202 }} // the grid will fill the size of the parent container
    >
      <Row >
        <Col>
          <Button variant='primary' onClick={handleNew}>Nuevo Litigio</Button>
        </Col>
        <Col>
          <Button variant='warning' onClick={handleEdit}>Modificar Litigio</Button>
        </Col>
        <Col>
          <Button variant='danger' onClick={handleDelete}>Eliminar Litigio</Button>
        </Col>
      </Row>
      <div>
        <FormLabel>Litigio seleccionado: </FormLabel>
        <span id="selectedRows"></span>
      </div>
      <AgGridReact
        ref={gridRef}
        rowData={litigations.response}
        columnDefs={colDefs}
        rowSelection={"single"}
        onSelectionChanged={onSelectionChanged}
      />
    </div>
  )
}