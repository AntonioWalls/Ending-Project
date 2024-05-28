import 'bootstrap/dist/css/bootstrap.min.css';
import { useEffect, useState, useRef, useCallback } from 'react';
import * as React from "react";
import { useDispatch, useSelector, useStore } from 'react-redux';
import { Button, Col, Row, FormLabel } from "react-bootstrap";
import { AgGridReact } from 'ag-grid-react'; // AG Grid Component
import "ag-grid-community/styles/ag-grid.css"; // Mandatory CSS required by the grid
import "ag-grid-community/styles/ag-theme-quartz.css"; // Optional Theme applied to the grid
import { getLitigious, deleteLitigious } from '../../../redux/actions/actionLitigious';
import Swal from "sweetalert2";

export default function TableLitigious({ showForm, idUserEdit }) {

  const [userSelected, setUserSelected] = React.useState(false);
  const [selectedState, setSelectedState] = React.useState({});

  // Rellenar grid con datos
  const dispatch = useDispatch();
  const { litigious } = useSelector((state) => state.getLitigious);


  // Obtener la id del usuario. 
  const [id, setId] = useState(0);
  const gridRef = useRef();
  const onSelectionChanged = useCallback(() => {
    const selectedRows = gridRef.current.api.getSelectedRows();
    document.querySelector("#selectedRows").innerHTML =
      selectedRows.length === 1 ? selectedRows[0].nombres : "";
    console.log(selectedRows[0].idLitigioso);
    setId(selectedRows[0].idLitigioso);
    console.log(id)

  }, []);



  useEffect(() => {
    dispatch(getLitigious());
    console.log(litigious);
  }, [dispatch]);

  // Column Definitions: Defines the columns to be displayed.
  const [colDefs, setColDefs] = useState([
    { field: 'idLitigioso', headerName: 'ID de Litigioso' },
    { field: 'nombres', headerName: 'Nombre' },
    { field: 'apellidos', headerName: 'Apellidos' },
    { field: 'rfc', headerName: 'RFC' },
    { field: 'curp', headerName: 'CURP' },
    { field: 'telefono', headerName: 'Telefono' },
    { field: 'calle', headerName: 'Calle' },
    { field: 'num', headerName: 'Numero' },
    { field: 'colonia', headerName: 'Colonia' },
    { field: 'municipio', headerName: 'Municipio' },
    { field: 'estado', headerName: 'Estado' },
    { field: 'cp', headerName: 'Codigo Postal' }
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
          showForm();
      }else{
          alert('Seleccione un usuario para modificar');
      }
  };

  const handleDelete = () => {

    if (id) {
      // Eliminar usuario seleccionado
      dispatch(deleteLitigious(id)).then(() => {
        Swal.fire({
          icon: "success",
          title: "Usuario eliminado",
          showConfirmButton: false,
          timer: 1500,
        }).then(() => {
          dispatch(getLitigious());
        });
      });
    } else {
      Swal.fire({
        icon: "error",
        title: "Error",
        text: "Seleccione un usuario para eliminar",
      });
      }

  };


  // ...

  return (

    // wrapping container with theme & size
    <div
      className="ag-theme-quartz" // applying the grid theme
      style={{ height: 500, width: 802 }} // the grid will fill the size of the parent container
    >
      <Row >
        <Col>
          <Button variant='primary' onClick={handleNew}>Nuevo Litigioso</Button>
        </Col>
        <Col>
          <Button variant='warning' onClick={handleEdit}>Modificar Litigioso</Button>
        </Col>
        <Col>
          <Button variant='danger' onClick={handleDelete}>Eliminar Litigioso</Button>
        </Col>
      </Row>
      <div>
        <FormLabel>Litigioso seleccionado: </FormLabel>
        <span id="selectedRows"></span>
      </div>
      <AgGridReact
        ref={gridRef}
        rowData={litigious.response}
        columnDefs={colDefs}
        rowSelection={"single"}
        onSelectionChanged={onSelectionChanged}
      />
    </div>
  )
}