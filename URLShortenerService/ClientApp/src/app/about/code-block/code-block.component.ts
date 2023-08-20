import { Component, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../../auth-service/auth-service';
@Component({
  selector: 'app-code-block',
  templateUrl: './code-block.component.html',
  styleUrls: ['./code-block.component.css']
})
export class CodeBlockComponent {
  @Input() code: string = '';
  @Output() codeChanged = new EventEmitter<string>();
  isEditing = false;
  editedCode: string = '';

  constructor(public authService: AuthService) {

  }
  startEditing() {
    this.isEditing = true;
    this.editedCode = this.code;
  }

  saveChanges() {
    this.isEditing = false;
    this.code = this.editedCode;
    this.codeChanged.emit(this.code);
  }
}
